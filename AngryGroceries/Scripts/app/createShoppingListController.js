angular.module('AngryGroceries').controller('CreateShoppingListController', function ($scope, dialog) {
    $scope.close = function (result) {

        $scope.errorMessage = "";

        if (!$scope.name && result) {
            $scope.errorMessage = "Please provide a name for the new shopping list";
            return;
        }

        dialog.close($scope.name);
    };
});