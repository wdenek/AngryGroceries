angular
    .module('AngryGroceries', [])
    .controller('indexController', ['$scope', function($scope) {

        $scope.message = 'Hello shopper';

    }]);