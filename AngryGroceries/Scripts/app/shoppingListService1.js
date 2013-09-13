angular.module('AngryGroceries').factory('shoppingListService', function ($http) {
    
    function getShoppingLists() {
        return $http.get('/api/shoppinglists').then(function(result) {
            return result.data;
        });
    }

    function getShoppingList(id) {
        return $http.get('/api/shoppinglists/' + id).then(function(result) {
            return result.data;
        });
    }
    
    function createShoppingList(name) {
        var data = {
            name: name
        };

        return $http.post('/api/shoppinglists/', data).then(function(result) {
            return result.data;
        });
    }
    
    function updateShoppingList(shoppingList) {
        return $http.put('/api/shoppinglists/', shoppingList).then(function(result) {
            return result.data;
        });
    }
    
    function deleteShoppingList(id) {
        return $http.delete('/api/shoppinglists/' + id).then(function(result) {
            return result.data;
        });
    }

    return {
        getShoppingLists: getShoppingLists,
        getShoppingList: getShoppingList,
        createShoppingList: createShoppingList,
        updateShoppingList: updateShoppingList,
        deleteShoppingList: deleteShoppingList
    };
});