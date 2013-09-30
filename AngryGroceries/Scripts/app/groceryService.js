angular.module('AngryGroceries').factory('groceryService', function($http) {
    var callbacks = {
        created: undefined,
        updated: undefined,
        deleted: undefined
    };

    var groceryHub = $.connection.groceryHub;
    $.connection.hub.logging = true;
    $.connection.hub.start()
        .done(function () {
            console.log("hub.start.done");
        })
        .fail(function (error) {
            console.log(error);
        });
    
    groceryHub.client.groceryCreated = function (grocery) {
        console.log('groceryCreated called from server.');
        
        if(callbacks.created && typeof(callbacks.created) === "function") {
            callbacks.created(grocery);
        }
    };

    groceryHub.client.groceryUpdated = function (grocery) {
        console.log('groceryUpdated called from server.');

        if(callbacks.updated && typeof(callbacks.updated) === "function") {
            callbacks.updated(grocery);    
        }
    };

    groceryHub.client.groceryDeleted = function (id) {
        console.log('groceryDeleted called from server.');

        if (callbacks.deleted && typeof(callbacks.deleted) === "function") {
            callbacks.deleted(id);
        }
    };

    function createGrocery(name, listId) {
        var grocery = {
            name: name  
        };
        
        return groceryHub.server.create(grocery, listId);
    }
     
    function updateGrocery(grocery) {
        groceryHub.server.update(grocery);
    }
    
    function deleteGrocery(id) {
        groceryHub.server.delete(id);
    }

    function getGroceries(id) {
        return $http.get('/api/groceries/' + id).then(function(result) {
            return result.data;
        });
    }

    return {
        createGrocery: createGrocery,
        updateGrocery: updateGrocery,
        deleteGrocery: deleteGrocery,
        getGroceries: getGroceries,
        callbacks: callbacks
    };
});