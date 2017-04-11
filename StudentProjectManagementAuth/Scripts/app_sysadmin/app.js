var app = angular.module("app", ['ui.bootstrap', 'ngRoute']);

//Routes
app.config(['$routeProvider', '$locationProvider', 

	function($routeProvider, $locationProvider) {

		$routeProvider
		.when ('/Dashboard', {
			templateUrl: '/Areas/Administrator/Administrator/Dashboard'
		})

		.when ('/Test', {
			template: '<h2 style="color: #FFFFFF">Test thanh</h2>'
		})

		.when ('/ProfessorManagement', {
			templateUrl: '/Areas/Administrator/Administrator/ProfessorManagement',
			controller: 'ProfessorManagementCtrl'
		})

		//.otherwise({ redirectTo: '/Dashboard' });

		//$locationProvider.html5Mode(true);

	}

])
