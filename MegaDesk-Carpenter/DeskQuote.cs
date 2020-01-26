using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Carpenter
{
    public class DeskQuote
    {
        //base price
        const int BASEPRICE = 200;
        const int BASESURFACEAREA = 1000;
        const int DRAWERCOST = 50;

        public DeskQuote(Desk desk, string firstName, string lastName, float surfaceArea, int shippingIndex)
        {
            this.desk = desk;
            this.firstName = firstName;
            this.lastName = lastName;
            this.surfaceArea = surfaceArea;
            this.shippingIndex = shippingIndex;
        }

        public Desk desk { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public float surfaceArea { get; set; }
        public int shippingIndex { get; set; }




        //surface area base price + $1 for each in^2
        public int PriceSurfaceArea()
        {
            if (surfaceArea > BASESURFACEAREA)
            {
                float SA = surfaceArea;
                int convSA = (int)surfaceArea;
                int cost = convSA - BASESURFACEAREA;
                return cost;

            }
            else
            {
                return 0;
            }
        }
        //drawers * 50
        public int PriceDrawers()
        {
            int drawers = desk.drawers;
            int cost = drawers * DRAWERCOST;
            return cost;

        }

        //surface material
        public int PriceSurface()
        {
            int cost;
            switch (desk.surfaceIndex)
            {
                case 0:
                    cost = 200;
                    break;
                case 1:
                    cost = 100;
                    break;
                case 2:
                    cost = 50;
                    break;
                case 3:
                    cost = 300;
                    break;
                case 4:
                    cost = 125;
                    break;
                default:
                    cost = 0;
                    break;


            }
            return cost;
        }

        //shipping type + surfaceArea < 1000, surfaceArea >= 1000  && surfaceArea <= 2000, surfaceArea > 2000 
        //index = 7 day = 1, 5 day = 2, 3 day = 3
        public int PriceRushOrder()
        {
            float SA = surfaceArea;
            int convSA = (int)surfaceArea;
            int cost = 0;
            if (convSA < BASESURFACEAREA)
            {
                if (shippingIndex == 0)
                {
                    cost = 0;
                }
                else if (shippingIndex == 1)
                {
                    cost = 30;
                }
                else if (shippingIndex == 2)
                {
                    cost = 40;
                }
                else if (shippingIndex == 3)
                {
                    cost = 60;
                }

                else if (1000 < convSA && convSA < 2000)
                {
                    if (shippingIndex == 0)
                    {
                        cost = 0;
                    }
                    else if (shippingIndex == 1)
                    {
                        cost = 35;
                    }
                    else if (shippingIndex == 2)
                    {
                        cost = 50;
                    }
                    else if (shippingIndex == 3)
                    {
                        cost = 70;
                    }
                }

                else if (convSA > 2000)
                {
                    if (shippingIndex == 0)
                    {
                        cost = 0;
                    }
                    else if (shippingIndex == 1)
                    {
                        cost = 40;
                    }
                    else if (shippingIndex == 2)
                    {
                        cost = 60;
                    }
                    else if (shippingIndex == 3)
                    {
                        cost = 80;
                    }
                }
                return cost;
                
            }
            else
            {
                return cost;
            }
        }

        //quote total: priceBase + priceDrawers + priceSurface + priceRushOrder
        public int Quote()
        {
            int cost = BASEPRICE + PriceSurfaceArea() + PriceDrawers() + PriceSurface() + PriceRushOrder();
            return cost;

        }



    }
}
