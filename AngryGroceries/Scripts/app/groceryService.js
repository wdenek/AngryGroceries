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
            if (subscribedListId) {
                console.log('hub connection started. subscribing to list: ' + subscribedListId);
                debugger;
                subscribeToList(subscribedListId);
            }

            if (unsubscribeListId) {
                console.log('hub connection started. unsubscribing from list: ' + unsubscribeListId);
                unsubscribeFromList(unsubscribeListId);
            }
        })
        .fail(function (error) {
            console.log('hub connection failed: %o', error);
        });

    var subscribedListId;
    var unsubscribeListId;

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

    function createGrocery(grocery, listId) {
         groceryHub.server.create(grocery, listId);
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
    
    function subscribeToList(id) {
        // 1. is the connection open? if so, call server directly
        // 2. if the connection is not open, store the id
        debugger;
        if ($.connection.hub.state ===  $.signalR.connectionState.connected) {
            groceryHub.server.subscribe(id);
        } else {
            subscribedListId = id;
        }
    }
    
    function unsubscribeFromList(id) {
        debugger;
        if ($.connection.hub.state === $.signalR.connectionState.connected) {
            groceryHub.server.unsubscribe(id);
        } else {
            unsubscribeListId = id;
        }
    }

    function generateCorrelationId() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }
    
    return {
        createGrocery: createGrocery,
        updateGrocery: updateGrocery,
        deleteGrocery: deleteGrocery,
        getGroceries: getGroceries,
        subscribeToList: subscribeToList,
        unsubscribeFromList: unsubscribeFromList,
        generateCorrelationId: generateCorrelationId,
        callbacks: callbacks
    };
});