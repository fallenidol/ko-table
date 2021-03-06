# ko-table #

** No longer maintained. **

After looking around I couldn't find a simple and clean way of making html tables pageable and sortable using knockoutjs. This is what I came up with. You might find it useful too.

## Usage ##
Please download the source solution and look at the demo page which has several examples of usage. 
In a nutshell though here is what you need to do...

Here is an example of what it looks like with a bog standard, bootstrap styled, table. 
To achieve this refer to the html and javascript below.

![An example table](/../artefacts/example_table.png "An example table")

#### HTML ####
The key thing to notice here is the ***koTable*** binding on the table element. The koTable binding will extend the viewModel object adding the necessary functions and fields required to support paging and sorting.

The tbody has a foreach binding bound to the ***pagedItems*** collection. But pagedItems isn't an object in the viewModel so where does it come from you cry? Well, it's added automatically by the ***koTable*** binding.


```html
<table id="table-1" class="table table-striped table-hover" data-bind="koTable: { pageSize: 10, showSearch: true, initialSortProperty: 'id', initialSortDirection: 'desc' }">
	<thead>
	    <tr>
	        <th data-sort-property="id">Id</th>
	        <th data-sort-property="name">Name</th>
	        <th data-sort-property="age">Age</th>
	        <th data-sort-property="company">Company</th>
	        <th data-sort-property="email">Email</th>
	        <th data-sort-property="phone">Phone</th>
	        <th data-sort-property="isActive">Active</th>
	    </tr>
	</thead>
	<tbody data-bind="foreach: koTable.pagedItems">
	    <tr>
	        <td><span data-bind="text: id"></span></td>
	        <td><span data-bind="text: name"></span></td>
	        <td><span data-bind="text: age"></span></td>
	        <td><span data-bind="text: company"></span></td>
	        <td><span data-bind="text: email"></span></td>
	        <td><span data-bind="text: phone"></span></td>
	        <td><span data-bind="css: { 'glyphicon-ok': isActive, 'glyphicon-remove': !isActive }" class="sort-icon glyphicon small" aria-hidden="true"></span></td>
	    </tr>
	</tbody>
</table>
```

#### JavaScript ####

Since the koTable binding extends the viewModel object all you really need to do to make the magic happen is to call self.setItems and pass your object array.

```javascript
var ViewModel = (function () {
    var self = this;

    self.getItemsFromServer = function () {
        $.get("api/Person").always(function (data) {
            // load the data we received
            self.koTable.setItems(data);
        });
    };

    // ready is automcatically invoked when koTable is initialized.
    self.koTableReady = function () {
        // load the data form the server
        self.getItemsFromServer();
    };

});

$(document).ready(function () {
    ko.applyBindings(new viewModel());
});

```
## Options ##

These are the options you can pass to the koTable binding:

- **pageSize**: the number of rows per page. Default is all (*i.e.* no paging).
- **showSearch**: show a search box in place of any ***ko-table-search*** classes. Default is false.
- **rowsClickable**: make rows clickable and raise an event when they are clicked. Default: true.
- **allowSort**: allows the grid to be sorted by column.
- **initialSortProperty**: the name of the property to initially sort by.
- **initialSortDirection**: the initial sort directon. Default is 'asc'.
- **showDeleteButton**: show a delete button for each row. Default is false.
- **showEditButton**: show an edit button for each row. Default is false.
- **showNewButton**: show a new button in the top lefft corner. Default is false.

## Requirements ##

You'll need to reference the following things in your web page: 

- [jquery](https://github.com/jquery/jquery)
- [knockoutjs](https://github.com/knockout/knockout)
- [knockout.mapping](https://github.com/SteveSanderson/knockout.mapping)
- [knockout.validation](https://github.com/Knockout-Contrib/Knockout-Validation)
- [bootstrap](https://github.com/twbs/bootstrap)

## Installation ##

## Nuget ##

Installation is easy from [nuget](https://www.nuget.org/packages/koTable/): 

```
PM> Install-Package koTable
```

## Manually ##

Assuming you've got the other requirements setup (see above) all you need to do is include a reference to either *[koTable.js](./wwwroot/scripts/_app/koTable.js)* or *[koTable.min.js](./wwwroot/scripts/_app/koTable.min.js)*

```html
<script src="Scripts/koTable.min.js"></script>
```
