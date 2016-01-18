var app = angular.module('photoset', []).controller('photosetCtrl', function ($scope, $http) {
    $scope.name = '';
    $scope.url = '';
    getPhotoSetList();
    $scope.error = false;
    $scope.incomplete = false;
    $scope.delset = function (id) {
        delPhotoSet(id);
    };
    $scope.addset = function ()
    {
        $scope.name = '';
        $scope.url = '';
    }
    $scope.return = function ()
    {
        window.location.href = "/Home/PhotoIndex";
    },
    $scope.insertset = function () {
        if ($("#file").val()=="") {
            toastr.error("请选择照片");
            return;
        }
        insertPhotoSet();
    }

    $scope.$watch('name', function () { $scope.test(); });

    $scope.test = function () {
        if ($scope.name == "") {
            $scope.error = true;
            return;
        }
        $scope.error = false;
        $scope.incomplete = false;
    };

    function getPhotoSetList() {
        $http.post("/Home/GetPhotoSetList")
       .success(function (data) {
           $scope.photosets = data;
       });
    }

    function delPhotoSet(id)
    {
        $http.post("/Home/DelPhotoSet", {"id":id})
        .success(function () {
            getPhotoSetList();
        });
    }

    function insertPhotoSet() {
        var options = {
            type: "POST",
            url: '/Home/InsertPhotoSet',
            data:{name:$scope.name},
            success: function () {
                getPhotoSetList();
            },
            error: function () {
                toastr.error("上传失败");
            }
        };
        $('#form').ajaxSubmit(options);
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
    $("[name=urlTd]").each(function () {
        var cl = $(this).html();
        $(this).html("");
        $(this).html("<img width=\"30px\" height=\"30px\" src=\"" + cl + "\"/>");
    });
}