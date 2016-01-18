var app = angular.module('index', []).controller('indexCtrl', function ($scope, $http) {
    getSmallSetList();
    function getSmallSetList() {
        $http.post("/Home/GetSmallSetList")
       .success(function (data) {
           $scope.smallsets = data;
           for (var i = 0; i < $scope.smallsets.length; i++) {
               turnplate.restaraunts.push($scope.smallsets[i].name);
               turnplate.colors.push($scope.smallsets[i].color);
               turnplate.ids.push($scope.smallsets[i].id);
           }
           drawRouletteWheel();
       });
    }
});
