function vAirportAdminDashboardv2() {

	this.chartId = 'myChart';
	this.service = 'airline';
	this.ctrlActions = new ControlActions();

	this.GetDataToChart2 = function (initializeChartFunction) {

		this.ctrlActions.GetToApi(this.service + '?type=activeInactiveAirlines', initializeChartFunction);
		
	};


}