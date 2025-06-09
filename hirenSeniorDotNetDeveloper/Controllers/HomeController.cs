using hirenSeniorDotNetDeveloper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace hirenSeniorDotNetDeveloper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var dateLabels = new List<string>
            {
            "20 Mar", "22 Mar", "24 Mar", "26 Mar", "28 Mar", "10 Mar", "1 Apr", "3 Apr"
            };

            var dashboardModel = new DashboardChartsViewModel
            {
                PieChart = CreateDoughnutChart(),
                BarChart = CreateBarChart(dateLabels),
                LineChart = CreateLineChart(dateLabels),
                StackedBarChart = CreateStackedBarChart(dateLabels)
            };

            return View(dashboardModel);
        }

        private ChartViewModel CreateStackedBarChart(List<string> labels)
        {
            return new ChartViewModel
            {
                ChartId = "stackedBarChart",
                ChartTitle = "Engine hours",
                ChartType = "bar",
                Labels = labels,
                Datasets = new List<ChartDataset>
                {
                    new ChartDataset
                    {
                        Label = "Red",
                        Data = new List<double> { 2, 3, 20, 5, 1, 4, 8, 12 },
                        BackgroundColor = "rgba(238,146,52,255)"
                    },
                    new ChartDataset
                    {
                        Label = "Blue",
                        Data = new List<double> { 12, 19, 3, 5, 2, 3, 15, 7 },
                        BackgroundColor = "rgba(0,142,67,255)"
                    }
                }
            };
        }

        private ChartViewModel CreateBarChart(List<string> labels)
        {
            return new ChartViewModel
            {
                ChartId = "messageReceivedChart",
                ChartTitle = "Messages Received",
                ChartType = "bar",
                Labels = labels,
                Datasets = new List<ChartDataset>
                {
                    new ChartDataset
                    {
                        Label = "Red",
                        Data = new List<double> { 2, 3, 2, 5, 1, 4, 8, 2 },
                        BackgroundColor = "rgba(206,108,29,255)"
                    },
                    new ChartDataset
                    {
                        Label = "Blue",
                        Data = new List<double> { 12, 19, 15, 5, 19, 8, 15, 14 },
                        BackgroundColor = "rgba(210,161,125,255)"
                    }
                }
            };
        }

        private ChartViewModel CreateLineChart(List<string> labels)
        {
            return new ChartViewModel
            {
                ChartId = "line",
                ChartTitle = "Traveled distance (431 KM)",
                ChartType = "line",
                Labels = labels,
                Datasets = new List<ChartDataset>
                {
                    new ChartDataset
                    {
                        Label = "Product A",
                        Data = new List<double> { 15, 18, 10, 20, 28, 8, 25, 10 },
                        BorderColor = "rgba(208,115,41,255)",
                        BackgroundColor = "rgba(230,181,141,255)",
                        Fill = true,
                        Tension = 0.4,
                        BorderWidth = 2
                    },
                    new ChartDataset
                    {
                        Label = "Product B",
                        Data = new List<double> { 20, 25, 15, 25, 20, 12, 22, 18 },
                        BorderColor = "rgba(232,210,194,255)",
                        BackgroundColor = "rgba(250,244,240,255)",
                        Fill = true,
                        Tension = 0.4,
                        BorderWidth = 2
                    }
                }
            };
        }

        private ChartViewModel CreateDoughnutChart()
        {
            return new ChartViewModel
            {
                ChartId = "doughnut",
                ChartTitle = "Activity breakdown (Hours)",
                ChartType = "doughnut",
                Labels = new List<string> { "Lgnition Off", "Lgnition", "Lding" },
                Datasets = new List<ChartDataset>
                {
                    new ChartDataset
                    {
                        Label = "Tasks",
                        Data = new List<double> { 60, 20, 20 },
                        BackgroundColor = new List<string>
                        {
                            "rgba(151,28,36,255)",
                            "rgba(0,142,67,255)",
                            "rgba(238,146,52,255)"
                        },
                        BorderRadius = 5,
                        BorderWidth = 2,
                        BorderColor = "#ffffff",
                        Spacing = 2
                    }
                }
            };
        }

        public IActionResult AssetTimeline()
        {
            var viewModel = new TimelineChartViewModel
            {
                ChartTitle = "Day Overview",
                AssetData = new Dictionary<string, List<AssetStatusBlock>>
                {
                    ["BL-08"] = new List<AssetStatusBlock>
                    {
                        new() { Start = "11:00", End = "11:15", Status = "idle" },
                        new() { Start = "11:15", End = "11:50", Status = "working" },
                        new() { Start = "11:50", End = "12:00", Status = "operating" },
                        new() { Start = "12:00", End = "12:01", Status = "error" },
                        new() { Start = "13:00", End = "16:00", Status = "operating" },
                        new() { Start = "16:00", End = "16:30", Status = "working" },
                        new() { Start = "16:30", End = "17:00", Status = "operating" },
                        new() { Start = "17:15", End = "17:30", Status = "operating" }
                    },
                    ["Q-47898"] = new List<AssetStatusBlock>
                    {
                        new() { Start = "11:00", End = "15:45", Status = "operating" },
                        new() { Start = "15:45", End = "16:00", Status = "error" },
                        new() { Start = "16:00", End = "17:00", Status = "operating" }
                    },
                    ["D-26653"] = new List<AssetStatusBlock>
                    {
                        new() { Start = "11:00", End = "11:20", Status = "idle" },
                        new() { Start = "11:20", End = "13:30", Status = "working" },
                        new() { Start = "13:30", End = "14:00", Status = "operating" },
                        new() { Start = "14:00", End = "14:30", Status = "working" },
                        new() { Start = "14:30", End = "15:00", Status = "operating" },
                        new() { Start = "15:00", End = "15:30", Status = "working" },
                        new() { Start = "15:30", End = "16:00", Status = "operating" }
                    }
                }
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }

}
