$(document).ready(function () {
    GetCartDate();
    weeklyReferral();
    weeklyLeads();
    leadsCategoriesAcross();
    GetTATReports();
    GetEnterprisesSolarized();
    GetPerformingDistricts();
    GetDistricts_SolarShopsMapped();
});
function GetCartDate() {
    $.ajax({
        url: document.baseURI + "/Reports/GetSummaryBoxCount/",
        type: 'GET',
        dataType: 'json',
        success: function (resp) {
            if (resp.IsSuccess) {
                var resD = JSON.parse(resp.Data);
                $('#ReferralReceived').text(resD.Table[0].Referral_Received);
                $('#QualifiedLeads').text(resD.Table[0].Qualified_Leads);
                $('#EnterprisesSolarized').text(resD.Table[0].Enterprises_Solarized);
                $('#CreditLinked').text(resD.Table[0].Credit_Linked);
                $('#ConversionRate').text(resD.Table[0].Conversion_Rate);
            } else {
                toastr.error("Error", '@(DeWee.Manager.Enums.eReturnReg.RecordNotFound)');
            }
        },
        error: function (xhr, status, error) {
            toastr.error("Error", '@(DeWee.Manager.Enums.eReturnReg.ExceptionError)' + error);
        }
    });
}
function weeklyReferral() {
    $.ajax({
        url: document.baseURI + "/Reports/GetWeeklyReffreal/",
        type: 'GET',
        dataType: 'json',
        success: function (resp) {
            var resD = JSON.parse(resp.Data); // expecting array of objects like: [{ Total: 724, Name: 'May-25' }, ...]

            // Extract x-axis labels and data values
            var categories = resD.map(item => item.Name);  // ['May-25', 'Jun-25']
            var data = resD.map(item => item.Total);       // [724, 497]

            Highcharts.chart('WeeklyReferral', {
                chart: {
                    type: 'areaspline'
                },
                lang: {
                    locale: 'en-GB'
                },
                title: {
                    text: 'Weekly Referral'
                },
                xAxis: {
                    categories: categories,
                    title: {
                        text: ''
                    }
                },
                yAxis: {
                    title: {
                        text: 'Total Referrals'
                    }
                },
                credits: {
                    enabled: false // 👈 This disables the Highcharts.com text
                },

                plotOptions: {
                    areaspline: {
                        color: '#F26C23',
                        fillColor: {
                            linearGradient: { x1: 0, x2: 0, y1: 0, y2: 1 },
                            stops: [
                                [0, '#F26C23'],
                                [1, '#F26C2300']
                            ]
                        },
                        threshold: null,
                        marker: {
                            lineWidth: 1,
                            lineColor: null,
                            fillColor: 'white'
                        }
                    }
                },
                series: [{
                    name: 'Referrals',
                    data: data,
                    showInLegend: false,
                }]
            });
        },
        error: function (xhr, status, error) {
            toastr.error("Error", 'Something went wrong: ' + error);
        }
    });
}
function weeklyLeads() {
    $.ajax({
        url: document.baseURI + "/Reports/GetWeeklyLeads/",
        type: 'GET',
        dataType: 'json',
        success: function (resp) {
            var resD = JSON.parse(resp.Data); // expecting array of objects like: [{ Total: 724, Name: 'May-25' }, ...]

            // Extract x-axis labels and data values
            var categories = resD.map(item => item.Name);  // ['May-25', 'Jun-25']
            var data = resD.map(item => item.Total);       // [724, 497]

            Highcharts.chart('weeklyLeads', {
                //chart: {
                //    type: 'areaspline'
                //},
                lang: {
                    locale: 'en-GB'
                },
                title: {
                    text: 'Weekly Leads'
                },
                xAxis: {
                    categories: categories,
                    title: {
                        text: ''
                    }
                },
                yAxis: {
                    title: {
                        text: 'Total Leads'
                    }
                },
                credits: {
                    enabled: false // This hides the "Highcharts.com" credit
                },
                legend: {
                    enabled: false // Hide the legend
                },
                //plotOptions: {
                //    areaspline: {
                //        color: '#32CD32',
                //        fillColor: {
                //            linearGradient: { x1: 0, x2: 0, y1: 0, y2: 1 },
                //            stops: [
                //                [0, '#32CD32'],
                //                [1, '#32CD3200']
                //            ]
                //        },
                //        threshold: null,
                //        marker: {
                //            lineWidth: 1,
                //            lineColor: null,
                //            fillColor: 'white'
                //        }
                //    }
                //},
                series: [{
                    name: 'Leads',
                    data: data,
                    showInLegend: false,
                }]
            });
        },
        error: function (xhr, status, error) {
            toastr.error("Error", 'Something went wrong: ' + error);
        }
    });
}
function leadsCategoriesAcross() {
    $.ajax({
        url: document.baseURI + "/Reports/GetLeadsCategoriesAcross/",
        type: 'GET',
        dataType: 'json',
        success: function (resp) {
            var resD = JSON.parse(resp.Data); // expecting array of objects like: [{ Total: 724, Name: 'May-25' }, ...]

            resD.sort(function (a, b) {
                if (a.BusinessTypeInEng === 'Other') return 1;
                if (b.BusinessTypeInEng === 'Other') return -1;
                return 0;
            });
            var pieData = resD.map(function (item, index) {
                return {
                    name: item.BusinessTypeInEng,
                    y: item.Total,
                    sliced: index === 0,        // First slice separated
                    selected: index === 0       // First slice selected
                };
            });

            Highcharts.chart('leadsCategoriesAcross', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'Top 5 Leads Categories Across All Enterprises'
                },
                tooltip: {
                    pointFormat: '<b>{point.y}</b> leads ({point.percentage:.1f}%)'
                },
                accessibility: {
                    point: {
                        valueSuffix: '%'
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle',
                    itemMarginTop: 5,
                    itemMarginBottom: 5,
                    labelFormatter: function () {
                        return this.name + ': ' + this.percentage.toFixed(1) + '%';
                    }
                },
                credits: {
                    enabled: false
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: false
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    name: 'Categories',
                    colorByPoint: true,
                    data: pieData
                }]
            });

        },
        error: function (xhr, status, error) {
            toastr.error("Error", 'Something went wrong: ' + error);
        }
    });
}

//function leadsCategoriesAcross() {
//    $.ajax({
//        url: document.baseURI + "/Reports/GetLeadsCategoriesAcross/",
//        type: 'GET',
//        dataType: 'json',
//        success: function (resp) {
//            var resD = JSON.parse(resp.Data); // expecting array of objects like: [{ Total: 724, Name: 'May-25' }, ...]

//            var pieData = resD.map(function (item, index) {
//                return {
//                    name: item.BusinessTypeInEng,
//                    y: item.Total,
//                    sliced: index === 0,        // First slice separated
//                    selected: index === 0      // First slice selected

//                };
//            });

//            Highcharts.chart('leadsCategoriesAcross', {
//                chart: {
//                    plotBackgroundColor: null,
//                    plotBorderWidth: null,
//                    plotShadow: false,
//                    type: 'pie'
//                },
//                title: {
//                    text: 'Top 5 Leads Categories Across All Enterprises'
//                },
//                tooltip: {
//                    pointFormat: '<b>{point.y}</b> leads ({point.percentage:.1f}%)'
//                },
//                accessibility: {
//                    point: {
//                        valueSuffix: '%'
//                    }
//                },
//                legend: {
//                    layout: 'vertical',
//                    align: 'right',
//                    verticalAlign: 'middle',
//                    itemMarginTop: 5,
//                    itemMarginBottom: 5,
//                    labelFormatter: function () {
//                        return this.name + ': ' + this.y;
//                    }
//                },
//                credits: {
//                    enabled: false // This hides the "Highcharts.com" credit
//                },
//                plotOptions: {
//                    pie: {
//                        allowPointSelect: true,
//                        cursor: 'pointer',
//                        dataLabels: {
//                            enabled: false
//                        },
//                        showInLegend: true
//                    }
//                },
//                credits: {
//                    enabled: false // 👈 This disables the Highcharts.com text
//                },
//                series: [{
//                    name: 'Categories',
//                    colorByPoint: true,
//                    data: pieData  // dynamically generated in the success function
//                }]
//            });

//        },
//        error: function (xhr, status, error) {
//            toastr.error("Error", 'Something went wrong: ' + error);
//        }
//    });
//}
function GetTATReports() {
    $.ajax({
        url: document.baseURI + "/Reports/GetTATReport/",
        type: "GET",
        dataType: "json",
        success: function (resp) {
            var resD = JSON.parse(resp.Data); // expecting array of objects like: [{ Total: 724, Name: 'May-25' }, ...]

            const chartData = Object.entries(resD[0]).map(([key, value]) => ({
                name: key.replaceAll('_', ' '),
                y: value !== null ? parseFloat(value) : null
            }));

            Highcharts.chart('tatReports', {
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'TAT Summary'
                },
                credits: {
                    enabled: false
                },
                legend: {
                    enabled: false
                },
                xAxis: {
                    type: 'category',
                    title: {
                        text: ''
                    }
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'TAT (in days)'
                    }
                },
                series: [{
                    name: 'TAT',
                    data: chartData
                }]
            });
        },
        error: function (xhr, status, error) {
            console.error("Error fetching cost lead data:", error);
        }
    });
}
function GetEnterprisesSolarized() {
    $.ajax({
        url: document.baseURI + "/Reports/GetEnterprisesSolarized/",
        type: "GET",
        dataType: "json",

        success: function (resp) {
            var resD = JSON.parse(resp.Data); // Now it's an array of objects with Name and Total

            // Prepare chart data
            const chartData = resD.map(item => ({
                name: item.Name,
                y: parseFloat(item.Total)
            }));

            // Create bar chart
            Highcharts.chart('chartenterprisesSolarized', {
                chart: {
                    type: 'bar'
                },
                title: {
                    text: 'Top 3 Enterprises Solarized'
                },
                credits: {
                    enabled: false
                },
                legend: {
                    enabled: false
                },
                xAxis: {
                    type: 'category',
                    title: {
                        text: ''
                    }
                },
                yAxis: {
                    visible: false
                },
                tooltip: {
                    pointFormat: 'Total: <b>{point.y}</b>'
                },
                plotOptions: {
                    series: {
                        dataLabels: {
                            enabled: true,
                            format: '{point.y}', // Show label on bar
                            style: {
                                fontWeight: 'bold'
                            }
                        }
                    }
                },
                series: [{
                    name: 'Total',
                    //color: '#007bff',
                    data: chartData
                }]
            });
        },
        error: function (xhr, status, error) {
            console.error("Error fetching cost lead data:", error);
        }
    });
}
function GetPerformingDistricts() {
    $.ajax({
        url: document.baseURI + "/Reports/GetPerformingDistricts/",
        type: "GET",
        dataType: "json",

        success: function (resp) {
            var resD = JSON.parse(resp.Data); // Now it's an array of objects with Name and Total

            // Prepare chart data
            const chartData = resD.map(item => ({
                name: item.Name,
                y: parseFloat(item.Total)
            }));

            // Create bar chart
            Highcharts.chart('graphPerformingDistricts', {
                chart: {
                    type: 'bar'
                },
                title: {
                    text: 'Top 3 Performing Districts'
                },
                credits: {
                    enabled: false
                },
                legend: {
                    enabled: false
                },
                xAxis: {
                    type: 'category',
                    title: {
                        text: ''
                    }
                },
                yAxis: {
                    visible: false
                },
                tooltip: {
                    pointFormat: 'Total: <b>{point.y}</b>'
                },
                plotOptions: {
                    series: {
                        dataLabels: {
                            enabled: true,
                            format: '{point.y}', // Show label on bar
                            style: {
                                fontWeight: 'bold'
                            }
                        }
                    }
                },
                series: [{
                    name: 'Total',
                    //color: '#007bff',
                    data: chartData
                }]
            });
        },
        error: function (xhr, status, error) {
            console.error("Error fetching cost lead data:", error);
        }
    });
}

function GetDistricts_SolarShopsMapped() {
    $.ajax({
        url: document.baseURI + "/Reports/GetSolarShopsMapped/",
        type: "GET",
        dataType: "json",

        success: function (resp) {
            var resD = JSON.parse(resp.Data); // Now it's an array of objects with Name and Total

            // Prepare chart data
            const chartData = resD.map(item => ({
                name: item.Name,
                y: parseFloat(item.Total)
            }));

            // Create bar chart
            Highcharts.chart('graphSolarShopsMapped', {
                chart: {
                    type: 'bar'
                },
                title: {
                    text: 'Top 3 Performing Districts'
                },
                credits: {
                    enabled: false
                },
                legend: {
                    enabled: false
                },
                xAxis: {
                    type: 'category',
                    title: {
                        text: ''
                    }
                },
                yAxis: {
                    visible: false
                },
                tooltip: {
                    pointFormat: 'Total: <b>{point.y}</b>'
                },
                plotOptions: {
                    series: {
                        dataLabels: {
                            enabled: true,
                            format: '{point.y}', // Show label on bar
                            style: {
                                fontWeight: 'bold'
                            }
                        }
                    }
                },
                series: [{
                    name: 'Total',
                    //color: '#007bff',
                    data: chartData
                }]
            });
        },
        error: function (xhr, status, error) {
            console.error("Error fetching cost lead data:", error);
        }
    });
}

function GetPerformingDistricts() {
    $.ajax({
        url: document.baseURI + "/Reports/GetPerformingDistricts/",
        type: "GET",
        dataType: "json",

        success: function (resp) {
            var resD = JSON.parse(resp.Data); // Now it's an array of objects with Name and Total

            // Prepare chart data
            const chartData = resD.map(item => ({
                name: item.Name,
                y: parseFloat(item.Total)
            }));

            // Create bar chart
            Highcharts.chart('graphPerformingDistricts', {
                chart: {
                    type: 'bar'
                },
                title: {
                    text: 'Top 3 Performing Districts'
                },
                credits: {
                    enabled: false
                },
                legend: {
                    enabled: false
                },
                xAxis: {
                    type: 'category',
                    title: {
                        text: ''
                    }
                },
                yAxis: {
                    visible: false
                },
                tooltip: {
                    pointFormat: 'Total: <b>{point.y}</b>'
                },
                plotOptions: {
                    series: {
                        dataLabels: {
                            enabled: true,
                            format: '{point.y}', // Show label on bar
                            style: {
                                fontWeight: 'bold'
                            }
                        }
                    }
                },
                series: [{
                    name: 'Total',
                    //color: '#007bff',
                    data: chartData
                }]
            });
        },
        error: function (xhr, status, error) {
            console.error("Error fetching cost lead data:", error);
        }
    });
}

