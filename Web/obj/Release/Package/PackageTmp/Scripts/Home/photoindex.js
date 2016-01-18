var jslottery;
var imgcount;
var photolist;
var app = angular.module('photoindex', []).controller('photoindexCtrl', function ($scope, $http) {
    getPhotoSetList();
    $scope.photodraw = function () {
        photodraw();
    };
    function getPhotoSetList() {
        $http.post("/Home/GetPhotoSetList")
       .success(function (data) {
           $scope.photosets = data;
           photolist = data;
           imgcount=data.length;
           $scope.$on('ngRepeatFinished', function (ngRepeatFinishedEvent) {
               loadDraw();
           });
       });
    }
    function photodraw() {
        jslottery.options.stop_position = Math.floor(Math.random() * 12 + 1);
        jslottery.options.speed = Math.floor(Math.random() * 200 + 300);
        jslottery.options.speed_up_position = Math.floor(Math.random() * 6 + 1);
        jslottery.options.speed_down_position = Math.floor(Math.random() * 6 + 1);
        jslottery.options.speedUp = Math.floor(Math.random() * 30 + 20);
        jslottery.options.speedDown = Math.floor(Math.random() * 100 + 600);
        jslottery.options.total_circle = Math.floor(Math.random() * 5 + 2);
        jslottery.start();
    }
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

function loadDraw() {
     jslottery = new Jslottery({
        scroll_dom: 'img-cell',
        scroll_dom_css_value: '/Images/houzi.jpg',
        scroll_dom_attr: 'id',
        scroll_dom_css: 'src',
        start_position: Math.floor(Math.random() * imgcount + 1),
        callback: function (data) {
            $.alert({
                title: '你真棒',
                content: "<img src=\"/Images/houzi.jpg\" width=\"40%\" heigth=\"40%\">恭喜"+photolist[data.data-1].name+"中了5000元大奖",
                confirmButton: '恭喜！'
            });
        }
    });
}
