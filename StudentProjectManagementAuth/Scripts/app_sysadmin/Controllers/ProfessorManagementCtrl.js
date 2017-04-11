app.controller('ProfessorManagementCtrl', ['$scope', '$http', '$modal',

	function ($scope, $http, $modal) {

	    $scope.Professor = {
	        Model: {
	        	UserName: "",
	        	Password: "",
	        	ConfirmPassword: ""
	        },
	        List: [],
	        ValidationList: [],
	        IsLoading: false,
	        NoResult: false,
	        TotalCount: 0
	    };

	    /*Create Professor*/
	    $scope.createProfessor = function () {
	        let model = angular.copy($scope.Professor.Model);
	        $http.post('/Administrator/Administrator/CreateProfessor', {model: model})
	        	.success(function(response) {
	        		$scope.showMessage(response.Status, response.Message);
	        		if (response.Status) {
	        			$scope.Professor.ValidationList = [];
	        			$scope.Professor.Model = {};
	        			$scope.Professor.List.push(response.Model);
	        		}
	        		else {
	        			$scope.Professor.ValidationList = response.ValiValidationMessage;
	        		}
	        	});
	    }

	    /*View Detail Professor*/
	    $scope.showPopupViewProfessor = function (item){
	    	let model = angular.copy(item);
	    	var modalInstance = $modal.open({
		      	templateUrl: '/Areas/Administrator/Templates/ViewProfessorModal.html',
		      	controller: "ViewProfessorCtrl",
		      	backdrop: 'static',
		      	size: 'md',
		      	resolve: {
		        	info: function () {
		        		return {
		        			item: model,
		        			success: function (status, message) {
		        				$scope.showMessage(status, message);
		        				if (status) {
		        					$scope.loadAllProfessor();
		        				}

		        			}
		        		}
		        	}
		      	}
		    });
	    }

	    /*Delete Professor*/
	    $scope.showPopupDeleteProfessor = function (index, item){
	    	let model = angular.copy(item);
	    	var modalInstance = $modal.open({
		      	templateUrl: '/Areas/Administrator/Templates/DeleteProfessorModal.html',
		      	controller: "DeleteProfessorCtrl",
		      	backdrop: 'static',
		      	size: 'md',
		      	resolve: {
		        	info: function () {
		        		return {
		        			item: model,
		        			success: function (status, message) {
		        				$scope.showMessage(status, message);
		        				if (status) {
		        					$scope.loadAllProfessor();
		        				}

		        			}
		        		}
		        	}
		      	}
		    });
	    }

	    /*Init Professor*/
	    $scope.loadAllProfessor = function () {
	    	if ($scope.Professor.IsLoading) {
	    		return;
	    	}

	    	$scope.Professor.IsLoading = true;

	    	$http.get('/Administrator/Administrator/LoadAllProfessor')
	        	.success(function(response) {
	        		$scope.Professor.List = response.Professors;
	        		$scope.Professor.TotalCount = response.TotalCount;
	        		if ($scope.Professor.TotalCount == 0) {
	        			$scope.Professor.NoResult = true;
	        		}
	        		$scope.Professor.IsLoading = false;

	        	});
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
	    	$scope.loadAllProfessor();
	    }

	    $scope.init();
	}

])

app.controller("ViewProfessorCtrl", ['$scope', '$modalInstance', 'info', '$http',

	function($scope, $modalInstance, info, $http) {

		$scope.Professor = angular.copy(info.item);

		$scope.cancel = function () {
		    $modalInstance.dismiss('cancel');
		};

	}

])

app.controller("DeleteProfessorCtrl", ['$scope', '$modalInstance', 'info', '$http',

	function($scope, $modalInstance, info, $http) {

		$scope.Professor = angular.copy(info.item);
		$scope.IsSubmitting = false;

		$scope.deleteProfessor = function () {
			if ($scope.IsSubmitting) {
				return;
			}

			$scope.IsSubmitting = true;
			$http.post('/Administrator/Administrator/DeleteProfessor', {model: $scope.Professor})
	        	.success(function(response) {
	        		if (response.Status) {
	        			$modalInstance.dismiss('cancel');
	        			info.success(response.Status, response.Message);
	        			$scope.Professor = null;	        		
	        		}	
	        		$scope.IsSubmitting = false;
	        	});

		}

		$scope.cancel = function () {
		    $modalInstance.dismiss('cancel');
		};

	}

])
