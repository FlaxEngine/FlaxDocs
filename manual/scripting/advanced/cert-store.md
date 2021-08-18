# Cert Store

When using `WebClient`, `WebRequest` or other SSL/TLS network connection to 3rd party server in C# script it might fail due to `TrustFailure`. That's because by default application doesn't have any trusted root Certificate Authority. The following tutorial shows how to overcome this problem.

### No validation

One solution to this problem is to provide the certificates that your game trusts for validation callback:

```cs
ServicePointManager.ServerCertificateValidationCallback +=
               delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                                        System.Security.Cryptography.X509Certificates.X509Chain chain,
                                        System.Net.Security.SslPolicyErrors sslPolicyErrors)
{
    // TODO: implement certificate validation (eg. trust official game server cert only)
    return true; // **Always accept
};
```

### Cert Store plugin

The best solution is to use a collection of root certificates that are trusted widely across the Internet such as provided by Mozzila. The example plugin below implements caching trusted root certificates collection in `RawDataAsset`. At runtime, it loads the certificates from the data and adds them to the Root so the following SSL requests will be validated upon those certificates.

Note that the first plugin start will take a few seconds because it will cache the newest certificates collection to the asset (stored in `Content/CertStore.flax`). Subsequential initializations take usually between 200-500ms. You can strip the certificates list for your needs to improve the setup time if needed.

```cs
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FlaxEngine;
using Debug = FlaxEngine.Debug;

/// <summary>
/// Trusted certificates store utility.
/// </summary>
public sealed class CertStore : GamePlugin
{
    // Reference: https://github.com/mono/mono/blob/main/mcs/tools/security/mozroots.cs

    /// <inheritdoc />
    public override PluginDescription Description => new PluginDescription
    {
        Name = "Cert Store",
        Category = "Other",
        Description = "Trusted certificates store utility.",
        Author = "Flax",
        AuthorUrl = "https://flaxengine.com/",
    };

    /// <inheritdoc />
    public override void Initialize()
    {
        base.Initialize();

        var timer = Stopwatch.StartNew();

        // Get data
        var asset = InitAsset();
        if (asset == null || asset.WaitForLoaded())
        {
            Debug.LogError("Missing certificates store!");
            return;
        }
        var data = asset.Data;

        // Load certificates
        var roots = new X509Certificate2Collection();
        var sb = new StringBuilder();
        bool processing = false;
        using (var stream = new MemoryStream(data))
        {
            var reader = new StreamReader(stream);
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                    break;
                if (processing)
                {
                    if (line.StartsWith("END"))
                    {
                        processing = false;
                        var root = DecodeCertificate(sb.ToString());
                        roots.Add(root);
                        sb = new StringBuilder();
                        continue;
                    }
                    sb.Append(line);
                }
                else
                {
                    processing = line.StartsWith("CKA_VALUE MULTILINE_OCTAL");
                }
            }
        }
        if (roots.Count == 0)
        {
            Debug.Log("No certificates found.");
            return;
        }

        // Apply certificates
        var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
        store.Open(OpenFlags.ReadWrite);
        X509CertificateCollection trusted = store.Certificates;
        foreach (var root in roots)
        {
            if (!trusted.Contains(root))
                store.Add(root);
        }
        store.Close();

        timer.Stop();
        Debug.Log(string.Format("Cert Store initialized in {0} ms with {1} certs", timer.ElapsedMilliseconds, roots.Count));
    }

#if FLAX_EDITOR
    /// <inheritdoc />
    public override void OnCollectAssets(System.Collections.Generic.List<Guid> assets)
    {
        base.OnCollectAssets(assets);

        // Reference cached certificates asset
        var asset = InitAsset();
        assets.Add(asset.ID);
    }
#endif

    private RawDataAsset InitAsset()
    {
        var path = Path.Combine(Globals.ProjectContentFolder, "CertStore.flax");
        var asset = Content.LoadAsync<RawDataAsset>(path);
        if (asset == null)
        {
#if FLAX_EDITOR
            Debug.Log("Updating certificates store...");
            var callback = ServicePointManager.ServerCertificateValidationCallback;
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            try
            {
                // Download trusted certificates collection
                var url = "https://hg.mozilla.org/releases/mozilla-release/raw-file/default/security/nss/lib/ckfw/builtins/certdata.txt";
                Debug.Log("Downloading certs from " + url);
                var req = (HttpWebRequest)WebRequest.Create(url);
                req.Timeout = 10000;
                var ms = new MemoryStream();
                req.GetResponse().GetResponseStream().CopyTo(ms);
                var data = ms.ToArray();
                Debug.Log("Got " + data.Length + " bytes");

                // Save to file
                var saver = Content.CreateVirtualAsset<RawDataAsset>();
                saver.Data = data;
                saver.Save(path);

                // Load it
                asset = Content.LoadAsync<RawDataAsset>(path);
            }
            finally
            {
                // Restore original certificate validation callback
                ServicePointManager.ServerCertificateValidationCallback = callback;
            }
            Debug.Log("Done.");
#endif
        }
        return asset;
    }

    private static X509Certificate2 DecodeCertificate(string s)
    {
        string[] pieces = s.Split('\\');
        byte[] data = new byte[pieces.Length - 1];
        for (int i = 1; i < pieces.Length; i++)
            data[i - 1] = (byte)((pieces[i][0] - '0' << 6) + (pieces[i][1] - '0' << 3) + (pieces[i][2] - '0'));
        return new X509Certificate2(data);
    }
}
```
