var app=angular.module('indexset', []).controller('indexsetCtrl', function ($scope,$http) {
    $scope.name = '';
    $scope.num = '';
    $scope.color = '';
    getSmallSetList();
    $scope.error = false;
    $scope.incomplete = false;
    $scope.delset = function (id) {
        delSmallSet(id);
    };
    $scope.addset = function ()
    {
        $scope.name = '';
        $scope.num = '';
        $scope.color = '';
    }
    $scope.return = function ()
    {
        window.location.href = "/Home/Index";
    },
    $scope.insertset = function () {
        insertSmallSet();
    }

    $scope.$watch('name', function () { $scope.test(); });
    $scope.$watch('color', function () { $scope.test(); });
    $scope.$watch('num', function () { $scope.test(); });

    $scope.test = function () {
        if ($scope.name == "" || $scope.color == "" || $scope.num=="") {
            $scope.error = true;
            return;
        }
        if (isNaN($scope.num)) {
            toastr.error("奖励数量必须为数字");
            $scope.error = true;
        }
        $scope.error = false;
        $scope.incomplete = false;
    };

    function getSmallSetList() {
        $http.post("/Home/GetSmallSetList")
       .success(function (data) {
           $scope.smallsets = data;
       });
    }

    function delSmallSet(id)
    {
        $http.post("/Home/DelSmallSet", {"id":id})
        .success(function () {
            getSmallSetList();
        });
    }

    function insertSmallSet() {
        var t = $("#color").spectrum("get");
        $http.post("/Home/InsertSmallSet", { "name": $scope.name, "num": $scope.num, "color": t.toHexString() })
        .success(function () {
            getSmallSetList();
        });
    }
    $scope.$on('ngRepeatFinished', function (ngRepeatFinishedEvent) {
        loadColor();
    });
});
app.directive('onFinishRenderFilters', function ($timeout) {
    return {
        restrict: 'A',
        link: function (scope, element, attr) {
            if (scope.$last === true) {
                $timeout(function () {
                    scope.$emit('ngRepeatFinished');
                });
            }
        }
    };
});

function loadColor() {
    $("[name=colorSpan]").each(function () {
        var cl = $(this).html();
        $(this).css("background-color",cl);
        $(this).html("转盘颜色");
    });
}