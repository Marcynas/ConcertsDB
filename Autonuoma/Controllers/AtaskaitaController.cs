using Microsoft.AspNetCore.Mvc;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using LateContractsReport = Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.LateContractsReport;
using ContractsReport = Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.ContractsReport;
using ServicesReport = Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.ServicesReport;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for producing reports.
	/// </summary>
	public class AtaskaitaController : Controller
	{

		/// <summary>
		/// Repository for Islaidos.
		/// </summary>
		/// <param name="dateFrom">Starting date. Can be null.</param>
		/// <param name="dateTo">Ending date. Can be null.</param>
		/// <returns>Report view.</returns>
		public IActionResult Islaidos(DateTime? dateFrom, DateTime? dateTo)
		{
			var report = AtaskaitaRepo.GetTotalIslaidos(dateFrom, dateTo);

			report.DateFrom = dateFrom;
			report.DateTo = dateTo?.AddHours(23).AddMinutes(59).AddSeconds(59); //move time of end date to end of day

			report.Islaidos = AtaskaitaRepo.GetIslaidosOrdered(dateFrom, dateTo);

			return View(report);
		}






		/// <summary>
		/// Produces services report.
		/// </summary>
		/// <param name="dateFrom">Starting date. Can be null.</param>
		/// <param name="dateTo">Ending date. Can be null.</param>
		/// <returns>Report view.</returns>
		public ActionResult Paslaugos(DateTime? dateFrom, DateTime? dateTo)
		{
			var report = AtaskaitaRepo.GetTotalServicesOrdered(dateFrom, dateTo);
			report.DateFrom = dateFrom;
			report.DateTo = dateTo?.AddHours(23).AddMinutes(59).AddSeconds(59); //move time of end date to end of day

			report.Paslaugos = AtaskaitaRepo.GetServicesOrdered(dateFrom, dateTo);

			return View(report);
		}

		/// <summary>
		/// Produces contracts report.
		/// </summary>
		/// <param name="dateFrom">Starting date. Can be null.</param>
		/// <param name="dateTo">Ending date. Can be null.</param>
		/// <returns>Report view.</returns>
		public ActionResult Sutartys(DateTime? dateFrom, DateTime? dateTo)
		{
			var report = new ContractsReport.Report();
			report.DateFrom = dateFrom;
			report.DateTo = dateTo?.AddHours(23).AddMinutes(59).AddSeconds(59); //move time of end date to end of day

			report.Sutartys = AtaskaitaRepo.GetContracts(report.DateFrom, report.DateTo);

			foreach (var item in report.Sutartys)
			{
				report.VisoSumaSutartciu += item.Kaina;
				report.VisoSumaPaslaugu += item.PaslauguKaina;
			}

			return View(report);
		}

		/// <summary>
		/// Produces late car returns reports.
		/// </summary>
		/// <param name="dateFrom">Starting date. Can be null.</param>
		/// <param name="dateTo">Ending date. Can be null.</param>
		/// <returns>Report view.</returns>
		public ActionResult Veluojancios(DateTime? dateFrom, DateTime? dateTo)
		{
			var report = new LateContractsReport.Report();
			report.DateFrom = dateFrom;
			report.DateTo = dateTo?.AddHours(23).AddMinutes(59).AddSeconds(59); //move time of end date to end of day

			report.Sutartys = AtaskaitaRepo.GetLateReturnContracts(report.DateFrom, report.DateTo);

			return View(report);
		}
	}
}
