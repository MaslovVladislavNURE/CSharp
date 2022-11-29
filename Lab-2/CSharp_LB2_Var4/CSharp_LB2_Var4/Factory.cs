using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CSharp_LB2_Var4
{
    class Factory : IComparable<Factory>
    {
        public string factoryName;
        public int numberWorkshops;
        public int amountWorkers;
        public int amountCraftsmen;
        public int salaryWorker;
        public int salaryCraftman;
        public int profitWorker;
        public int profitCraftman;

        //конструктор без параметрів
        public Factory()
        {
            factoryName = "";
            numberWorkshops = 0;
            amountWorkers = 0;
            amountCraftsmen = 0;
            salaryWorker = 0;
            salaryCraftman = 0;
            profitWorker = 0;
            profitCraftman = 0;
        }

        //конструктор копіювання
        public Factory(Factory factory)
        {
            factoryName = factory.factoryName + " (copy)";
            numberWorkshops = factory.numberWorkshops;
            amountWorkers = factory.amountWorkers;
            amountCraftsmen = factory.amountCraftsmen;
            salaryWorker = factory.salaryWorker;
            salaryCraftman = factory.salaryCraftman;
            profitWorker = factory.profitWorker;
            profitCraftman = factory.profitCraftman;
        }

        public int CompareTo(Factory other)
        {
            if (salaryWorker > other.salaryWorker && salaryCraftman > other.salaryCraftman)
                return 1;
            else if (salaryWorker < other.salaryWorker && salaryCraftman > other.salaryCraftman)
                return 2;
            else if (salaryWorker > other.salaryWorker && salaryCraftman < other.salaryCraftman)
                return 3;
            else if (salaryWorker < other.salaryWorker && salaryCraftman < other.salaryCraftman)
                return 4;

            else if (salaryWorker == other.salaryWorker && salaryCraftman < other.salaryCraftman)
                return 5;
            else if (salaryWorker == other.salaryWorker && salaryCraftman > other.salaryCraftman)
                return 6;
            else if (salaryWorker < other.salaryWorker && salaryCraftman == other.salaryCraftman)
                return 7;
            else if (salaryWorker > other.salaryWorker && salaryCraftman == other.salaryCraftman)
                return 8;
            else return 9;
        }
    }

    //реалізація Extension-методу для визначення доходу
    static class Extension
    {
        public static int income(this Factory factory, int investment)
        {
            int result = 0;
            int salary = investment;
            int c = 0;

            while (salary > 0)
            {
                if (salary - factory.salaryWorker > 0)
                {
                    c++;
                    salary -= factory.salaryWorker;
                }
                else
                    break;
            }
            result = c * factory.salaryWorker / factory.profitWorker;
            return result;
        }
    }
}
