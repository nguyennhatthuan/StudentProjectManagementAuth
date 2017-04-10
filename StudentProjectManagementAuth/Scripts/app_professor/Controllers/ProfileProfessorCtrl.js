angular.module("app", ['ui.bootstrap', 'angular-img-cropper'])

.controller('ProfileProfessorCtrl', ['$scope', '$http', '$modal', 

	function ($scope, $http, $modal) {

        $scope.Professor = {
            Model: "",
            IsLoading: false,
            Flag: {
                Phone: false,
                Email: false,
                FullName: false,
                Address: false
            }
        };

        $scope.ShowBtnEdit = false;
        $scope.IsSubmitting = false;

        //Get Infomation Professor
        $scope.getInfoProfessor = function() {
            if ($scope.Professor.IsLoading)
                return;
            $scope.Professor.IsLoading = true
            $http.get('/Professor/Professor/GetInfoProfessor')
                .success(function(response) {
                    $scope.Professor.Model = angular.copy(response.model);
                    if ($scope.isNullOrEmptry($scope.Professor.Model.Phone)) 
                        $scope.Professor.Flag.Phone = true;
                    else $scope.Professor.Flag.Phone = false;
                    if ($scope.isNullOrEmptry($scope.Professor.Model.Email)) {
                        $scope.Professor.Flag.Email = true;
                    }
                    else $scope.Professor.Flag.Email = false;
                    if ($scope.isNullOrEmptry($scope.Professor.Model.FullName)) {
                        $scope.Professor.Flag.FullName = true;
                    }
                    else $scope.Professor.Flag.FullName = false;
                    if ($scope.isNullOrEmptry($scope.Professor.Model.Address)) {
                        $scope.Professor.Flag.Address = true;
                    }
                    else $scope.Professor.Flag.Address = false;    
                    $scope.Professor.IsLoading = false;
                });
        }

        //Change Password
        $scope.changePassword = function(userName) {
            var modalInstance = $modal.open({
                templateUrl: '/Areas/Professor/Templates/ChangePasswordModal.html',
                controller: "ChangePasswordCtrl",
                backdrop: 'static',
                resolve: {
                    info: function () {
                        return {
                            userName: userName,
                            success: function (status, message) {
                            	$scope.showMessage(status, message);
                            }
                        }
                    }
                }
            });
        }

        //Show Button
        $scope.showBtnEdit = function(flag) {
            $scope.ShowBtnEdit = flag;
        }

        //Save Update Info
        $scope.saveUpdateInfo = function() {
            if ($scope.IsSubmitting) {
                return;
            }
            $scope.IsSubmitting = true;
            $http.post('/Professor/Professor/SaveUpdateInfo', {model: $scope.Professor.Model})
                .success(function(response) {
                    $scope.showMessage(response.Status, response.Message);
                    if (response.Status) {
                        $scope.ShowBtnEdit = false;
                        if ($scope.isNullOrEmptry($scope.Professor.Model.Phone)) 
                            $scope.Professor.Flag.Phone = true;
                        else $scope.Professor.Flag.Phone = false;
                        if ($scope.isNullOrEmptry($scope.Professor.Model.Email)) {
                            $scope.Professor.Flag.Email = true;
                        }
                        else $scope.Professor.Flag.Email = false;
                        if ($scope.isNullOrEmptry($scope.Professor.Model.FullName)) {
                            $scope.Professor.Flag.FullName = true;
                        }
                        else $scope.Professor.Flag.FullName = false;
                        if ($scope.isNullOrEmptry($scope.Professor.Model.Address)) {
                            $scope.Professor.Flag.Address = true;
                        }
                        else $scope.Professor.Flag.Address = false;
                    }
                    $scope.IsSubmitting = false;
                });   
        }

        $scope.isNullOrEmptry = function(string) {
            if (string == "" || string == null) {
                return true;
            }
            return false;
        }

	    //Show Message
        $scope.showMessage = function(status, message) {
            if (Boolean(status)) {
                var priority = 'success';
                var title    = 'Notes';

                $.toaster({ priority : priority, title : title, message : message });
            }
            else {
                var priority = 'danger';
                var title    = 'Notes';

                $.toaster({ priority : priority, title : title, message : message });
            }
        }

	    $scope.init = function() {
	    	$scope.getInfoProfessor();
	    }


	    $scope.init();
	}

])

.controller("ChangePasswordCtrl", ['$scope', '$modalInstance', 'info', '$http',

	function($scope, $modalInstance, info, $http) {

		$scope.IsSubmitting = false;
		$scope.Professor = {
			UserName: info.userName,
			Password: "",
			ConfirmPassword: "",
			ValidationMessageList: []
		};
		
		$scope.save = function() {
			if ($scope.IsSubmitting) {
				return;
			}
			$scope.IsSubmitting = true;
			$http.post('/Professor/Professor/ChangePasswordProfile', {
				userName: $scope.Professor.UserName, 
				password: $scope.Professor.Password, 
				confirmPassowrd: $scope.Professor.ConfirmPassword}
				)	.success(function(response) {
		        		if (response.Status) {
		        			$scope.cancel();
		        			$scope.Professor = null;
		        			info.success(response.Status, response.Message);
		        		}	
		        		else {
		        			$scope.Professor.ValidationMessageList = response.ValidationMessageList
		        		}
		        		$scope.IsSubmitting = false;
		        	});
		}

		$scope.cancel = function () {
		    $modalInstance.dismiss('cancel');
		};

	}

])

.controller("ChangeAvatarCtrl", ['$scope', '$modalInstance', 'info', '$http',

    function($scope, $modalInstance, info, $http) {

        $scope.cropper = {
            sourceImage: info.image,
            croppedImage: ""
        }; 

        //console.log(info);
        $scope.save = function() {
            return;
        }

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        }

        $scope.init = function() {
            $scope.cropper.sourceImage = info.image;
        }

        $scope.init();
    }

])