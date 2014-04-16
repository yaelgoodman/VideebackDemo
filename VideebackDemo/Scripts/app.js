var app = angular.module('groupPageApp', ["ngRoute", "ngResource"]);

app.factory('UserProfile', function ($resource) {
    return $resource('/api/UserProfile/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

app.controller('videoDivController', function ($scope) {
    $scope.closeVideo = function (state) {
        document.getElementById("dvShowVideo").style.display = "none";
    }
});

app.controller('calculateDatesDiff', function ($scope) {
    $scope.init = function (dateCreated) {
        $scope.lastPosted = calculateDatesDiff(dateCreated);
    }
});

function calculateDatesDiff(dateCreated) {
    //yyyy'-'MM'-'dd'T'HH':'mm':'ss
    //var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
    //return (Date.now()).toString();
   
    var oneMinute = 60 * 1000;
    var firstDate = new Date(dateCreated.toString());
    var secondDate = new Date();
    var threeHours =3* 60 * 60 * 1000; // temporary fix- DateTime.Now() and new Date are 3 hours apart.
    var diff = Math.abs((firstDate.getTime() - threeHours - secondDate.getTime()));
    var div = Math.floor(diff / oneMinute);
    //var rem = diff % oneMinute;
    if (div >= 60) {
        div = Math.floor(div / 60);
        if (div >= 24) {
            div = Math.floor(div / 24);
            if (div >= 30) {
                return ('long ago..')//more then a month ago - TO BE CONTINUED.. (week, year)
            }
            else {
                if (div == 1) {
                    return (div + ' day ago');
                }
                return (div + ' days ago');
            }
        }
        else {
            if (div == 1) {
                return (div + ' hour ago');
            }
            return (div + ' hours ago');
        }
    }
    else {
        if (div == 1) {
            return (div + ' minute ago');
        }
        return (div + ' minutes ago');
    }
}

app.controller('userProfileController', function ($scope, $location, UserProfile) {
    $scope.UserPofiles = UserProfile.query();
    // $scope.newField = "TTt";
    $scope.calculateDatesDiff = function (DateCreated) {
        document.getElementById("lblTest").src = updateSrc;
    }


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


