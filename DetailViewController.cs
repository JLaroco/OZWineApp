using System;

using UIKit;

namespace OZ_WINE_APP
{
	public partial class DetailViewController : UIViewController
	{
		public object DetailItem { get; set; }

		public DetailViewController (IntPtr handle) : base (handle)
		{
		}

		public void SetDetailItem (object newDetailItem)
		{
			if (DetailItem != newDetailItem) {
				DetailItem = newDetailItem;
				
				// Update the view
				ConfigureView ();

			}
		}

		void ConfigureView ()
		{
			// Update the user interface for the detail item
			if (IsViewLoaded && DetailItem != null)
				detailDescriptionLabel.Text = DetailItem.ToString ();
		try {
				
				if (detailDescriptionLabel.Text == "Ferm: Brix to SG & Sugar Content") {
					ConversionText1.Text = "Brix:";
					ConversionText2.Text = "Specific Gravity:";
					ConversionText3.Text = "Sugar Content:";
					ConversionText4.Hidden = true; 
					ConversionText5.Hidden = true; 
					ConversionText6.Hidden = true;

					//Set the User Interaction & Hidden Property -
					ConversionTextBox2.UserInteractionEnabled = false;
					ConversionTextBox3.UserInteractionEnabled = false;
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox2.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox3.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox4.Hidden = true;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction & Hidden Property +

					//Add Calculation -
					//
					//
					//Calculation.Text = "Specific Gravity = (Brix/(258.6-((Brix/258.2)*277.1)))+1 Sugar Content = Specific Gravity * 10";
					//Add Calculation +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double Brix = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double SG = Math.Round((Brix/(258.6-((Brix/258.2)*277.1)))+1,2);
						Double SC = Math.Round(SG*10,2);
						ConversionTextBox2.Text = System.Convert.ToString(SG);
						ConversionTextBox3.Text = System.Convert.ToString(SC);
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in brix to get specific gravity and sugar content. \n\nCalculation:\nSpecific Gravity = (Brix/(258.6-((Brix/258.2)*277.1)))+1\nSugar Content = Specific Gravity * 10";
						alert.Show();
					};
				} 
				else if (detailDescriptionLabel.Text == "Ferm: Brix to Alc. Conversion"){
					ConversionText1.Text = "Actual Brix of Must:";
					ConversionText2.Text = "Alc. Conversion Factor:";
					ConversionText3.Text = "Future level of wine:";
					ConversionText4.Text = "";
					ConversionText5.Text = "";
					ConversionText6.Text = "";

					//Set the User Interaction & Hidden Property -
					ConversionTextBox3.UserInteractionEnabled = false;
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox3.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox4.Hidden = true;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction & Hidden Property +

					//Add Calculation -
					//Calculation.Text = "Future level of wine = Brix * Alcohol Conversion Factor";
					//Add Calculation +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double x = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double y = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double z = Math.Round(x*y,2);

						ConversionTextBox3.Text = System.Convert.ToString(z);
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in brix & alcohol conversion factor of must to get future level of wine. \n\nCalcuation:\nFuture level of wine = Brix * Alcohol Conversion Factor";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "Ferm: Yeast") {

					ConversionText1.Text = "Volume of juice (gal):";
					ConversionText2.Text = "Yeast Rate (g/L):";
					ConversionText3.Text = "Yeast (g) to add:";
					ConversionText4.Text = "";
					ConversionText5.Text = "";
					ConversionText6.Text = "";

					//Set the User Interaction & Hidden Property -
					ConversionTextBox3.UserInteractionEnabled = false;
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox3.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox4.Hidden = true;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction & Hidden Property +

					//Add Calculation -
					//Calculation.Text = "Yeast to add = Volume of Juice * Yeast Rate * 3.785";
					//Add Calculation +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {

						Double Volume2 = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double RateAddition2 = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double AmountToAdd2 = Math.Round((Volume2 * RateAddition2 * 3.785),2);
						ConversionTextBox3.Text = System.Convert.ToString(AmountToAdd2);
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in volume of juice (gallons) & yeast rate (g/L) to get yeast (g) to add.\n\nCalcuation:\nYeast to add = Volume of Juice * Yeast Rate * 3.785";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "Ferm: Nutrients") {
					ConversionText1.Text = "Volume of juice (gal):";
					ConversionText2.Text = "Nutrients Rate (g/L):";
					ConversionText3.Text = "Nutrients (g) to add:";
					ConversionText4.Text = "";
					ConversionText5.Text = "";
					ConversionText6.Text = "";

					//Set the User Interaction & Hidden Property -
					ConversionTextBox3.UserInteractionEnabled = false;
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox3.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox4.Hidden = true;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction & Hidden Property +

					//Add Calculation -
					//Calculation.Text = "Yeast to add = Volume of Juice * Yeast Rate * 3.785";
					//Add Calculation +

	
					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {

						Double Volume2 = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double RateAddition2 = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double AmountToAdd2 = Math.Round((Volume2 * RateAddition2 * 3.785),2);
						ConversionTextBox3.Text = System.Convert.ToString(AmountToAdd2);
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in volume of juice (gallons) & nutrients rate (g/L) to get yeast (g) to add.\n\nCalcuation:\nNutrients to add = Volume of Juice * Nutrients Rate * 3.785";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "Water Dilution"){
					ConversionText1.Text = "Volume of must (gal):";
					ConversionText2.Text = "Desired Brix:";
					ConversionText3.Text = "Initial Brix:";
					ConversionText4.Text = "Water Required (g):";
					ConversionText5.Text = "";
					ConversionText6.Text = "";

					//Set the User Interaction -
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox4.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double VolumnOfMust = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double DesiredBrix = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double InitialBrix = System.Convert.ToDouble(ConversionTextBox3.Text);
						Double WaterReqired = System.Convert.ToDouble(ConversionTextBox4.Text);

						WaterReqired = (VolumnOfMust*(DesiredBrix-InitialBrix))/(0-DesiredBrix);
						WaterReqired = Math.Round(WaterReqired,2);

						ConversionTextBox4.Text = System.Convert.ToString(WaterReqired);
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in volume of must (gallons), desired brix & initial brix to get water required (g).\n\nCalcuation:\nWater Required (g) = (Volume of Must*(Desired Brix - Initial Brix))/(0 - Desired Brix)";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "SO2 Add: Liquid Solution") {
					ConversionText1.Text = "Volume of must (gal):";
					ConversionText2.Text = "SO2 Add Rate (ppm):";
					ConversionText3.Text = "Concentration (%w/v):";
					ConversionText4.Text = "Volume of SO2 to add (mL):";
					ConversionText5.Text = "";
					ConversionText6.Text = "";

					//Set the User Interaction -
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox4.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double VolumnOfMust = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double SO2AddRate = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double LiquidSolution = System.Convert.ToDouble(ConversionTextBox3.Text);
						Double ToAdd = System.Convert.ToDouble(ConversionTextBox4.Text);

						ToAdd = (SO2AddRate*3.785*VolumnOfMust)/(LiquidSolution*10);
						ToAdd = Math.Round(ToAdd,2);

						ConversionTextBox4.Text = System.Convert.ToString(ToAdd);
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in volume of must (gallons), SO2 addition rate (ppm) & concentration (%w/v) to get volume of SO2 to add (mL).\n\nCalcuation:\nVolume of SO2 (mL) = (Volume of Must*(Desired Brix - Initial Brix))/(0 - Desired Brix)";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "SO2 Add: Potassium Metablesulfite") {
					ConversionText1.Text = "Volume of Wine (gal):";
					ConversionText2.Text = "Target SO2 to add (ppm):";
					ConversionText3.Text = "Amt. KMBS to add (grams):";
					ConversionText4.Text = "";
					ConversionText5.Text = "";
					ConversionText6.Text = "";

					//Set the User Interaction & Hidden Property -
					ConversionTextBox3.UserInteractionEnabled = false;
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox3.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox4.Hidden = true;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction & Hidden Property +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double VolumnOfMust = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double TargetSO2 = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double ToAdd = System.Convert.ToDouble(ConversionTextBox3.Text);

						ToAdd = (TargetSO2*3.785*VolumnOfMust)/(1000*0.57);
						ToAdd = Math.Round(ToAdd,2);

						ConversionTextBox3.Text = System.Convert.ToString(ToAdd);
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in volume of wine (gallons) & target SO2 to add (ppm) to get KMBS to add (grams).\n\nCalcuation:\nKMBS (grams) = (Target SO2 * 3.785 * Volume of wine)/(1000 * 0.57)";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "SO2 Reduction") {
					ConversionText1.Text = "Volume of Wine (Liters):";
					ConversionText2.Text = "Target SO2 to remove (mg/L):";
					ConversionText3.Text = "Concentration of H202 (%w/w):";
					ConversionText4.Text = "Volume of H202 to add (mL):";
					ConversionText5.Text = "";
					ConversionText6.Text = "";

					//Set the User Interaction -
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox4.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double VolumnOfMust = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double TargetSO2 = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double Concentration = System.Convert.ToDouble(ConversionTextBox3.Text);
						Double ToRemove = System.Convert.ToDouble(ConversionTextBox4.Text);

						Double EBuf = (VolumnOfMust*TargetSO2*0.9)/1000;
						Double FBuf = EBuf*(34/64);
						ToRemove = FBuf*(100/Concentration);
						ToRemove = Math.Round(ToRemove,2);

						ConversionTextBox4.Text = System.Convert.ToString(ToRemove);
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in volume of wine (liters), Target SO2 to remove (mg/L) & concentration of H202 (%w/w) to get volume of H202 to add (mL).\n\nCalcuation:\nVolume of H202 to add (mL) = ((Volume of wine * Target SO2 to remove * 0.9)/1000)*(34/64)*(100/Concentration of H202)";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "Acid Addition") {
					ConversionText1.Text = "Volume of Wine (gal):";
					ConversionText2.Text = "Acid Addition Rate (g/L):";
					ConversionText3.Text = "Amt. of Acid to add (grams):";
					ConversionText4.Text = "";
					ConversionText5.Text = "";
					ConversionText6.Text = "";

					//Set the User Interaction & Hidden Property -
					ConversionTextBox3.UserInteractionEnabled = false;
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox3.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox4.Hidden = true;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction & Hidden Property +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double VolumnOfMust = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double AddRate = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double ToAdd = System.Convert.ToDouble(ConversionTextBox3.Text);

						ToAdd = (3.785 * VolumnOfMust * AddRate);
						ToAdd = Math.Round(ToAdd,2);

						ConversionTextBox3.Text = System.Convert.ToString(ToAdd);
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in volume of wine (gallons) & Acid Addition Rate (g/L) to get Amount of Acid to add (grams).\n\nCalcuation:\nAmount of Acid to add (grams) = 3.785 * Volume of Must * Acid Addition Rate";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "Oak Addition") {
					ConversionText1.Text = "Volume of Wine (gal):";
					ConversionText2.Text = "Oak Addition Rate (g/L):";
					ConversionText3.Text = "Amt. of Oak to add (grams):";
					ConversionText4.Text = "";
					ConversionText5.Text = "";
					ConversionText6.Text = "";

					//Set the User Interaction & Hidden Property -
					ConversionTextBox3.UserInteractionEnabled = false;
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox3.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox4.Hidden = true;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction & Hidden Property +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double VolumnOfMust = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double AddRate = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double ToAdd = System.Convert.ToDouble(ConversionTextBox3.Text);

						ToAdd = (3.785 * VolumnOfMust * AddRate);
						ToAdd = Math.Round(ToAdd,2);

						ConversionTextBox3.Text = System.Convert.ToString(ToAdd);
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in volume of wine (gallons) & Oak Addition Rate (g/L) to get Amount of Oak to add (grams).\n\nCalcuation:\nAmount of Oak to add (grams) = 3.785 * Volume of Must * Oak Addition Rate";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "Fining") {
					ConversionText1.Text = "Volume of Wine (gal):";
					ConversionText2.Text = "Fining Addition Rate (g/L):";
					ConversionText3.Text = "Amt. of Fining Agent to add (grams):";
					ConversionText4.Text = "";
					ConversionText5.Text = "";
					ConversionText6.Text = "";

					//Set the User Interaction & Hidden Property -
					ConversionTextBox3.UserInteractionEnabled = false;
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox3.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox4.Hidden = true;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction & Hidden Property +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double VolumnOfMust = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double AddRate = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double ToAdd = System.Convert.ToDouble(ConversionTextBox3.Text);

						ToAdd = (3.785 * VolumnOfMust * AddRate);
						ToAdd = Math.Round(ToAdd,2);

						ConversionTextBox3.Text = System.Convert.ToString(ToAdd);
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in volume of wine (gallons) & Fining Agent Addition Rate (g/L) to get Amount of Fining Agent to add (grams).\n\nCalcuation:\nAmount of Fining Agent to add (grams) = 3.785 * Volume of Must * Fining Agent Addition Rate";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "Molecular SO2") {
					ConversionText1.Text = "Desired Molecular SO2 (mg/L):";
					ConversionText2.Text = "pH of the wine:";
					ConversionText3.Text = "Requires Free SO2 (mg/L):";
					ConversionText4.Text = "";
					ConversionText5.Text = "";
					ConversionText6.Text = "";

					//Set the User Interaction & Hidden Property -
					ConversionTextBox3.UserInteractionEnabled = false;
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox3.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox4.Hidden = true;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction & Hidden Property +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double DesiredSO2 = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double pHofWine= System.Convert.ToDouble(ConversionTextBox2.Text);
						Double RequiresFree = System.Convert.ToDouble(ConversionTextBox3.Text);

						Double DBuf = (pHofWine-1.81);
						RequiresFree = DesiredSO2*(1+Math.Pow(10,DBuf));
						RequiresFree = Math.Round(RequiresFree,2);

						ConversionTextBox3.Text = System.Convert.ToString(RequiresFree);
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in desired molecular SO2 (mg/L) & pH of wine to get required free SO2 (mg/L).\n\nCalcuation:\nRequired Free SO2 (mg/L) = Desired Molecular SO2 * (1 + 10^(pH of Wine - 1.81))";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "Copper Add: Copper Sulfate CuSO4") {
					ConversionText1.Text = "Volume of Wine (L):";
					ConversionText2.Text = "Copper Addition Rate (mg/L):";
					ConversionText3.Text = "Amt. of CuSO4 to add (g):";
					ConversionText4.Text = "";
					ConversionText5.Text = "";
					ConversionText6.Text = "";

					//Set the User Interaction & Hidden Property -
					ConversionTextBox3.UserInteractionEnabled = false;
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox3.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox4.Hidden = true;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction & Hidden Property +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double VolumeOfWine = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double CopperRateAdd = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double AmtToAdd = System.Convert.ToDouble(ConversionTextBox3.Text);

						AmtToAdd = (VolumeOfWine*CopperRateAdd)/1000;
						AmtToAdd = Math.Round(AmtToAdd,2);

						ConversionTextBox3.Text = System.Convert.ToString(AmtToAdd);
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in volume of wine (Liters) & Copper Addition Rate (mg/L) to get Amount of CuSO4 to add (grams).\n\nCalcuation:\nAmount of CuSO4 to add (grams) = (Volume of Wine * Copper Addition Rate)/1000";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "Ferm: Temp. Corrections") {
					ConversionText1.Text = "Actual SG of Wine:";
					ConversionText2.Text = "Temp of Wine (F):";
					ConversionText3.Text = "Corrected SG of Wine:";
					ConversionText4.Text = "";
					ConversionText5.Text = "";
					ConversionText6.Text = "";

					//Set the User Interaction & Hidden Property -
					ConversionTextBox3.UserInteractionEnabled = false;
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox3.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox4.Hidden = true;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction & Hidden Property +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double ActualSG = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double TempOfWine = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double CorrectedSG = System.Convert.ToDouble(ConversionTextBox3.Text);

						Double DBuf = TempOfWine*TempOfWine;
						Double EBuf = TempOfWine*TempOfWine*TempOfWine;
						Double FBuf = 1.313454 - (0.132674*TempOfWine) + (0.002057793*DBuf) - (0.000002627634*EBuf);

						CorrectedSG = ActualSG + (FBuf*0.001);
						CorrectedSG = Math.Round(CorrectedSG,2);

						ConversionTextBox3.Text = System.Convert.ToString(CorrectedSG);
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in Actual Specific Gravity of Wine & Temperature of Wine (F) to get Corrected Specific Gravity of Wine.\n\nCalcuation:\nSpecific Gravity of Wine = 1.313454 - (0.132674 * Temperature of Wine) + (0.002057793 * (Temperature of Wine)^2) - (0.000002627634* (Temperature of Wine)^3)";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "Ferm: SG Sugar conversions") {
					ConversionText1.Text = "Specific Gravity of Must:";
					ConversionText2.Text = "Brix of Must:";
					ConversionText3.Text = "Plato of Must:";
					ConversionText4.Text = "Oechsle of Must:";
					ConversionText5.Text = "Baume of Must:";
					ConversionText6.Text = "Sugar Content of Must (g/L):";

					//Set the User Interaction & Hidden Property -
					ConversionTextBox2.UserInteractionEnabled = false;
					ConversionTextBox3.UserInteractionEnabled = false;
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox2.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox3.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox4.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox5.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox6.BorderStyle = UITextBorderStyle.None;
					//Set the User Interaction & Hidden Property +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double SG = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double Brix = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double Plato = System.Convert.ToDouble(ConversionTextBox3.Text);
						Double Oechsle = System.Convert.ToDouble(ConversionTextBox4.Text);
						Double Baume = System.Convert.ToDouble(ConversionTextBox5.Text);
						Double SugarContent = System.Convert.ToDouble(ConversionTextBox6.Text);
					
						//Calculations -
						Brix = (((182.4601*SG-775.6821)*SG+1262.7794)*SG-669.5622);
						Double GBuf = Brix*SG;
						SugarContent = 10*GBuf;
						Oechsle = 1000*(SG-1.0);
						Baume = 145 - (145/SG);

						Double XBuf = SG*SG;
						Double YBuf = SG*SG*SG;
						Plato = (-1*616.868)+(1111.14*SG)-(630.272*XBuf)+(135.997*YBuf);
						//Calculations +

						//Rounding -
						Brix = Math.Round(Brix,2);
						Plato = Math.Round(Plato,2);
						Oechsle = Math.Round(Oechsle,2);
						Baume = Math.Round(Baume,2);
						SugarContent = Math.Round(SugarContent,2);
						//Rounding +

						//Set Value -
						ConversionTextBox2.Text = System.Convert.ToString(Brix);
						ConversionTextBox3.Text = System.Convert.ToString(Plato);
						ConversionTextBox4.Text = System.Convert.ToString(Oechsle);
						ConversionTextBox5.Text = System.Convert.ToString(Baume);
						ConversionTextBox6.Text = System.Convert.ToString(SugarContent);
						//Set Value +
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in Specific Gravity to get Brix, Plato, Oechsle, Baume & Sugar Content.\n\nCalcuation:\nBrix = (((182.4601 * Specific Gravity - 775.6821) * Specific Gravity + 1262.7794) * Specific Gravity - 669.5622)\nPlato = (-1 * 616.868) + (1111.14 * Specific Gravity) - (630.272 * Specific Gravity^2) + (135.997 * Specific Gravity^3)\nOechsle = 1000 * (Specific Gravity - 1)\nBaume = 145 - (145/Specific Gravity)\nSugar Content = 10 * (Brix * Specific Gravity)";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "Chaptalization") {
					ConversionText1.Text = "Current Brix:";
					ConversionText2.Text = "Desired Brix:";
					ConversionText3.Text = "Wine Volume:";
					ConversionText4.Text = "Mass of Sugar to add (Kg):";
					ConversionText5.Text = "";
					ConversionText6.Text = "";

					//Set the User Interaction & Hidden Property -
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox4.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox5.Hidden = true;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction & Hidden Property +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double CurrentBrix = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double DesiredBrix = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double WineVolume = System.Convert.ToDouble(ConversionTextBox3.Text);
						Double SugarToAdd = System.Convert.ToDouble(ConversionTextBox4.Text);

						//Calculations -
						Double XBuf = CurrentBrix*CurrentBrix;
						Double YBuf = CurrentBrix*CurrentBrix*CurrentBrix;
						Double ABuf = DesiredBrix*DesiredBrix;
						Double BBuf = DesiredBrix*DesiredBrix*DesiredBrix;

						Double EBuf = (0.00000005785037196*YBuf)+(0.00001261831344*XBuf)+(0.003873042366*CurrentBrix)+0.9999994636;
						Double FBuf = (0.00000005785037196*BBuf)+(0.00001261831344*ABuf)+(0.003873042366*DesiredBrix)+0.9999994636;

						Double GBuf = 1000 * EBuf * CurrentBrix/100;
						Double HBuf = 1000 * FBuf * DesiredBrix/100;

						SugarToAdd = ((HBuf-GBuf)*WineVolume)/1000;
						//Calculations +

						//Rounding -
						SugarToAdd = Math.Round(SugarToAdd,2);
						//Rounding +

						//Set Value -
						ConversionTextBox4.Text = System.Convert.ToString(SugarToAdd);
						//Set Value +
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in Specific Gravity to get Mass of Sugar to Add (Kg).\n\nCalcuation:\nX = (0.00000005785037196 * (Current Brix^3)) + (0.00001261831344 * (Current Brix^2))+(0.003873042366 * Current Brix) + 0.9999994636\nY = (0.00000005785037196 * (Desired Brix^3)) + (0.00001261831344 * (Desired Brix^2))+(0.003873042366 * Desired Brix) + 0.9999994636\nA = 1000 * X * Current Brix/100\nB = 1000 * Y * Desired Brix/100\nSugar to Add = ((B - A) - Wine Volume)/1000";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "Deacidification") {
					ConversionText1.Text = "Actual TA of wine (g/L):";
					ConversionText2.Text = "Target TA of wine (g/L):";
					ConversionText3.Text = "Wine Volume to be treated (L):";
					ConversionText4.Text = "Calcium Carbonate (CaCO3) grams:";
					ConversionText5.Text = "Potassium Bicarbondate (KHCO3) grams:";
					ConversionText6.Text = "Potassium Carbonate (K2CO3) grams:";

					//Set the User Interaction & Hidden Property -
					ConversionTextBox4.UserInteractionEnabled = false;
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox4.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox5.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox6.BorderStyle = UITextBorderStyle.None;
					//Set the User Interaction & Hidden Property +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double ActualTA = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double TargetTA = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double VolumeOfWine = System.Convert.ToDouble(ConversionTextBox3.Text);
						Double CC = System.Convert.ToDouble(ConversionTextBox4.Text);
						Double PBC = System.Convert.ToDouble(ConversionTextBox5.Text);
						Double PC = System.Convert.ToDouble(ConversionTextBox6.Text);

						//Calculations -
						Double ABuf = 100.093/150.087;
						Double BBuf = 138.2001/150.087;
						Double CBuf = 200.216/150.087;

						CC = (ActualTA-TargetTA) * VolumeOfWine * ABuf;
						PBC = (ActualTA-TargetTA) * VolumeOfWine * BBuf;
						PC = (ActualTA-TargetTA) * VolumeOfWine * CBuf;
						//Calculations +

						//Rounding -
						CC = Math.Round(CC,2);
						PBC = Math.Round(PBC,2);
						PC = Math.Round(PC,2);
						//Rounding +

						//Set Value -
						ConversionTextBox4.Text = System.Convert.ToString(CC);
						ConversionTextBox5.Text = System.Convert.ToString(PBC);
						ConversionTextBox6.Text = System.Convert.ToString(PC);
						//Set Value +
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in Actual TA of wine (g/L),Target TA of wine (g/L), Wine Volume to be treated (Liter) to get " +
							"Calcium Carbonate (CaCO3),Potassium Bicarbondate (KHCO3), & Potassium Carbonate (K2CO3)\n\nCalcuation:\nCalcium Carbonate (CaCO3) = (Actual TA of wine - Target TA of wine) * Volume of Wine * (100.093/150.087)" +
							"\nPotassium Bicarbondate (KHCO3) = (Actual TA of wine - Target TA of wine) * Volume of Wine * (138.2001/150.087)" +
							"\nPotassium Carbonate (K2CO3) = (Actual TA of wine - Target TA of wine) * Volume of Wine * (200.216/150.087)";
						alert.Show();
					};
				} else if (detailDescriptionLabel.Text == "Fortification") {
					ConversionText1.Text = "Volume of Wine (gal):";
					ConversionText2.Text = "Alc. level of Spirits (%v/v):";
					ConversionText3.Text = "Alc. level of Wine ($v/v):";
					ConversionText4.Text = "Target Alc. level after Fortification (%v/v):";
					ConversionText5.Text = "Volume of Spirit to add:";
					ConversionText6.Text = "";

					//Set the User Interaction & Hidden Property -
					ConversionTextBox5.UserInteractionEnabled = false;
					ConversionTextBox6.UserInteractionEnabled = false;
					ConversionTextBox5.BorderStyle = UITextBorderStyle.None;
					ConversionTextBox6.Hidden = true;
					//Set the User Interaction & Hidden Property +

					ClearButton.TouchUpInside += (object sender, EventArgs e) => {
						ConversionTextBox1.Text = System.Convert.ToString(0.0);
						ConversionTextBox2.Text = System.Convert.ToString(0.0);
						ConversionTextBox3.Text = System.Convert.ToString(0.0);
						ConversionTextBox4.Text = System.Convert.ToString(0.0);
						ConversionTextBox5.Text = System.Convert.ToString(0.0);
						ConversionTextBox6.Text = System.Convert.ToString(0.0);
					};

					CalculateButton.TouchUpInside += (object sender, EventArgs e) => {
						Double VolumeOfWine = System.Convert.ToDouble(ConversionTextBox1.Text);
						Double AlcSpirits = System.Convert.ToDouble(ConversionTextBox2.Text);
						Double AlcWine = System.Convert.ToDouble(ConversionTextBox3.Text);
						Double TargetAlcLevel = System.Convert.ToDouble(ConversionTextBox4.Text);
						Double ToAdd = System.Convert.ToDouble(ConversionTextBox5.Text);

						//Calculations -
						Double FBuf = AlcSpirits-TargetAlcLevel;
						Double GBuf = TargetAlcLevel - AlcWine;
						Double HBuf = GBuf/FBuf;
						ToAdd = VolumeOfWine*HBuf;
						//Calculations +

						//Rounding -
						ToAdd = Math.Round(ToAdd,2);
						//Rounding +

						//Set Value -
						ConversionTextBox5.Text = System.Convert.ToString(ToAdd);
						//Set Value +
					};

					HelpButton.TouchUpInside += (object sender, EventArgs e) => {
						UIAlertView alert = new UIAlertView();
						alert.Title = "TeraVina Help";
						alert.AddButton("OK");
						alert.Message = "Please enter in Volume of Wine (gallons), Alcohol level of Spirits (%v/v), Alcohol level of Wine (%v/v) & Target Alcohol level after Fortification (%v/v) to get " +
							"Volume of Spirit to add.\n\nCalcuation:\n" +
							"Volume of Spirit to Add = Volume of Wine * ((Target Alcohol level (%v/v) - Alcohol level of Wine (%v/v))/(Alcohol level of Spirits (%v/v) - (Target Alcohol level (%v/v))";
						alert.Show();
					};
				}

			}catch(Exception e){
				Console.WriteLine (e.Message);
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			ConfigureView ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
				
		}

		/*partial void UIButton779_TouchUpInside (UIButton sender)
		{
			throw new NotImplementedException ();
		}*/
	}
}


