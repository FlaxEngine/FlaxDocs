# iOS

## Technical information

Flax supports **iOS 14 or newer**. For graphics rendering Vulkan is used via MoltenVK to run on Metal.

## iOS Setup

Follow these steps to setup your development PC for building game for iOS platform. In case of problems, please follow official documentation of iOS platform.

* Install **XCode** 
* Install **.Net iOS Workload**
  * Run `dotnet workload install ios` via command line
  * More info: [https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-workload-install](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-workload-install)

### Troubleshooting

* If you're getting the error `Missing NET SDK runtime for iOS ARM64.` then install iOS workload for dotnet (as mentioned above). It contains .Net libs, tools and runtime for iOS required to run C#.

## Build options

| Property | Description |
|--------|--------|
| **Output** | The built game output folder (relative to the project). |
| **Show Output** | If checked, after building the output folder will be shown in an Explorer. |
| **Configuration Mode** | Game building mode. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Release**</td><td>The release build ready for shipment.</td></tr><tr><td>**Debug**</td><td>The debug build for testing and profiling. Most of the code optimizations are disabled for the best debugging experience.</td></tr><tr><td>**Development**</td><td>The development build for testing and profiling but is more optimized for runtime than Debug build.</td></tr></tbody></table>|

## Platform settings

| Property | Description |
|--------|--------|
| **App Identifier** | The app identifier (reversed DNS, eg. com.company.product). Custom tokens: `${PROJECT_NAME}`, `${COMPANY_NAME}`. |
| **Override Icon** | Custom icon texture to use for the application (overrides the default one). |
