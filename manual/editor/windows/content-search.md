# Content Search

<figure class="video_container">
  <video autoplay muted loop poster="media/content-search.png">
    <source src="media/content-search-tool.mp4" type="video/mp4">
  </video>
</figure>

The **Content Search** is a utility window for searching inside a project content. It can be used to find all usages of a given asset name or Visual Script method across various assets such as:
* Visual Scripts
* Materials
* Animation Graphs
* Particle Emitters

To open this window use `Ctrl+F` in the graph editor (eg. in Visual Script), or use *Window -> Content Search* option in the main menu. Also, you can *right-click* on a parameter or method node in the graph and select the option **Find references...** which will summon the search window and start searching content.

### Search options

* **Search field** - value matching is text-based and searches for any occurrence of the input text in all values (case insensitive). If the input text value is indie parenthesis then it will be searched for an exact match.
* **Search Location** - option for search range which can be: *Current Asset* to search currently opened assets, *All Opened Assets** to search in all opened assets, or *All Assets* to search all the content.
* **Search Assets** - option for specifying the type of assets to search. By default, it's set to the asset type of the summoning window but can be configured to search in the whole project.
