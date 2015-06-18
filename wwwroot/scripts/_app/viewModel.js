﻿/*global toastr: true, $: true, sw: true */

var ViewModel = (function () {
    var self = this;

    self.loadAllData = function () {
        // signal start of something that might take a while
        self.waitStart();

        $.getJSON("api/Data", null, function (data) {

            console.log(data);
            // load the data we received
            self.setItems(data);

            // signal end
            self.waitEnd();
        });
    }

    // onInit is automcatically invoked when koTable is loaded.
    self.onInit = function () {
        sw.elapsed('onInit');

        // load the data form the server
        self.loadAllData();

        // hook up handler for when a row is clicked
        self.onRowClicked(function (evt) {
            console.log(evt);
            toastr.info(evt.data.model.name, "You clicked a row!");
        });
    };

});