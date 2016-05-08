using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OZ_WINE_APP
{
	public class ProdOrderListObject
	{
		//Constructors -
		public ProdOrderListObject ()
		{
		}

		public ProdOrderListObject (List<ProdOrderObject> POL) {
			ProductionOrderList = POL;
		}
		//Constructors +

		//Methods -
		public void AddToList (ProdOrderObject POO) {
			ProductionOrderList.Add (POO);
		}
		//Methods +

		public List<ProdOrderObject> getProdList {
			get { return ProductionOrderList; }
		}

		public void setProdList(List<ProdOrderObject> POO2) {
			ProductionOrderList = POO2;
		}

		//Properties -
		public List<ProdOrderObject> ProductionOrderList { get; set; }
		//Properties +
	}
}

