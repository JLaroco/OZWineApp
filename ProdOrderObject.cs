using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OZ_WINE_APP
{
	public class ProdOrderObject
	{
		public ProdOrderObject()
		{
		}

		public ProdOrderObject (string PN, double PNQ, string IN, string ID, double NOCO, double GC, string LN, string FT, double CL, string [] PMC, double HW, string d, string um, string poed, double prodq, double planq)
		{
			ProductionNo = PN;
			ProductionNoQty = PNQ;
			ItemNo = IN;
			ItemDescription = ID;
			NoOfCasesOutput = NOCO;
			GallonsConsumed = GC;
			LotNo = LN;
			FromTank = FT;
			CalcLoss = CL;
			PackagingMaterialConsumption = PMC;
			HoursWorked = HW;
			POStartDate = d;
			UOM = um;
			POEndDate = poed;
			ProducedQty = prodq;
			PlannedQty = planq;
		}

		public string ProductionNo { get; set; }
		public double ProductionNoQty { get; set; }
		public string ItemNo { get; set; }
		public string ItemDescription { get; set; }
		public double NoOfCasesOutput { get; set; }
		public double GallonsConsumed { get; set; }
		public string LotNo { get; set; }
		public string FromTank { get; set; }
		public double CalcLoss { get; set; }
		public string [] PackagingMaterialConsumption { get; set; }
		public double HoursWorked { get; set; }
		public string POStartDate { get; set; }
		public string UOM { get; set; }
		public string POEndDate { get; set; }
		public double ProducedQty { get; set; }
		public double PlannedQty { get; set; }


	}
}

