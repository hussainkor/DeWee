$(document).ready(function () {
    GetCartDate();
    weeklyReferral();
    weeklyLeads();
    leadsCategoriesAcross();

});

//function GetCartDate() {
//    $.ajax({
//        url: document.baseURI + "/Reports/GetSummaryBoxCount/",
//        type: 'GET',
//        dataType: 'json',
//        //data: {
//        //    CId: '1', SId: SId, DId: DId, BId: BId,
//        //    TypeOfEnterpriseId: TypeofEnterpriseBusinId, TypeofIndicator: TypeofIndicator
//        //},
        
//        success: function (resp) {
//            debugger;
//            var resD = JSON.parse(resp.Data);
//            $('#ReferralReceived').text(resD.Table[0].ReferralReceived);
//            $('#QualifiedLeads').text(resD.Table[0].QualifiedLeads);
//            $('#EnterprisesSolarized').text(resD.Table[0].EnterprisesSolarized);
//            $('#CreditLinked').text(resD.Table[0].CreditLinked);
//            $('#ConversionRate').text(resD.Table[0].ConversionRate);
//            dislist = resD.Table1;
//            AllDataBFY = resD.Table2;
//            tblTHR = resD.Table3;
//            if ((AllDataBFY != null && AllDataBFY != undefined) || (tblTHR != null && tblTHR != undefined))
//                LoadGoogleMap(AllDataBFY, tblTHR);
//            else
//                toastr.error("Error", '@(DeWee.Manager.Enums.eReturnReg.RecordNotFound)');
//        },
//        error: function (xhr, status, error) {
//            toastr.error("Error", '@(DeWee.Manager.Enums.eReturnReg.ExceptionError)' + error);
//        }
//    });
//}
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
                        text: 'Month'
                    }
                },
                yAxis: {
                    title: {
                        text: 'Total Referrals'
                    }
                },
                creadit: false,

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
                    data: data
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
                        text: 'Month'
                    }
                },
                yAxis: {
                    title: {
                        text: 'Total Leads'
                    }
                },
                creadit: false,

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
                    data: data
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

            // Extract x-axis labels and data values
            //var categories = resD.map(item => item.Name);  // ['May-25', 'Jun-25']
            //var data = resD.map(item => item.Total);       // [724, 497]

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
                        return this.name + ': ' + this.y;
                    }
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
                    data: pieData  // dynamically generated in the success function
                }]
            });

        },
        error: function (xhr, status, error) {
            toastr.error("Error", 'Something went wrong: ' + error);
        }
    });
}
