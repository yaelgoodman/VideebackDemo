var app = angular.module('groupPageApp', ["ngRoute", "ngResource"]);

app.factory('UserProfile', function ($resource) {
    return $resource('/api/UserProfile/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

app.controller('videoDivController', function ($scope) {
    $scope.closeVideo = function (state) {
        document.getElementById("dvShowVideo").style.display = "none";
    }
});

app.controller('userProfileController', function ($scope, $location, UserProfile) {
    $scope.UserPofiles = UserProfile.query();
    $scope.expandYouTube = function (code) {
        $scope.code = code;
        var updateSrc = "http://www.youtube.com/embed/" + code;

        document.getElementById("iframeYouTubeVid").src = updateSrc;

        document.getElementById("dvShowVideo").style.display = "inline";
    }
});

function toggleVideo(state) {
    var div = document.getElementById("popupVid");
    var iframe = div.getElementsByTagName("iframe")[0].contentWindow;
    div.style.display = state == 'hide' ? 'none' : '';
    func = state == 'hide' ? 'pauseVideo' : 'playVideo';
    iframe.postMessage('{"event":"command","func":"' + func + '","args":""}', '*');
}
