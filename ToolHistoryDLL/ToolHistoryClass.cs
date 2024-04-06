/* Title:           Tool History Class
 * Date:            1-2-18
 * Author:          Terry Holmes
 * 
 * Description:     This is used for Tool History */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace ToolHistoryDLL
{
    public class ToolHistoryClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        ToolHistoryDataSet aToolHistoryDataSet;
        ToolHistoryDataSetTableAdapters.toolhistoryTableAdapter aToolHistoryTableAdapter;

        InsertToolHistoryEntryTableAdapters.QueriesTableAdapter aInsertToolHistoryTableAdapter;

        FindToolHistoryByDateRangeDataSet aFindToolHistoryByDateRangeDataSet;
        FindToolHistoryByDateRangeDataSetTableAdapters.FindToolHistoryByDateRangeTableAdapter aFindToolHistoryByDateRangeTableAdapter;

        FindToolHistoryByEmployeeIDDataSet aFindToolHistoryByEmployeeIDDataSet;
        FindToolHistoryByEmployeeIDDataSetTableAdapters.FindToolHistoryByEmployeeIDTableAdapter aFindToolHistoryByEmployeeIDTableAdapter;

        FindToolHistoryByToolKeyDataSet aFindToolHistoryByToolKeyDataSet;
        FindToolHistoryByToolKeyDataSetTableAdapters.FindToolHistoryByToolKeyTableAdapter aFindToolHistoryByToolKeyTableAdapter;

        public FindToolHistoryByToolKeyDataSet FindToolHistoryByToolKey(DateTime datStartDate, DateTime datEndDate, int intToolKey)
        {
            try
            {
                aFindToolHistoryByToolKeyDataSet = new FindToolHistoryByToolKeyDataSet();
                aFindToolHistoryByToolKeyTableAdapter = new FindToolHistoryByToolKeyDataSetTableAdapters.FindToolHistoryByToolKeyTableAdapter();
                aFindToolHistoryByToolKeyTableAdapter.Fill(aFindToolHistoryByToolKeyDataSet.FindToolHistoryByToolKey, datStartDate, datEndDate, intToolKey);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Find Tool History by ToolKey " + Ex.Message);
            }

            return aFindToolHistoryByToolKeyDataSet;
        }
        public FindToolHistoryByEmployeeIDDataSet FindToolHistoryByEmployeeID(DateTime datStartDate, DateTime datEndDate, int intEmployeeID)
        {
            try
            {
                aFindToolHistoryByEmployeeIDDataSet = new FindToolHistoryByEmployeeIDDataSet();
                aFindToolHistoryByEmployeeIDTableAdapter = new FindToolHistoryByEmployeeIDDataSetTableAdapters.FindToolHistoryByEmployeeIDTableAdapter();
                aFindToolHistoryByEmployeeIDTableAdapter.Fill(aFindToolHistoryByEmployeeIDDataSet.FindToolHistoryByEmployeeID, datStartDate, datEndDate, intEmployeeID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Find Tool History by Employee ID " + Ex.Message);
            }

            return aFindToolHistoryByEmployeeIDDataSet;
        }
        public FindToolHistoryByDateRangeDataSet FindToolHistoryByDateRange(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindToolHistoryByDateRangeDataSet = new FindToolHistoryByDateRangeDataSet();
                aFindToolHistoryByDateRangeTableAdapter = new FindToolHistoryByDateRangeDataSetTableAdapters.FindToolHistoryByDateRangeTableAdapter();
                aFindToolHistoryByDateRangeTableAdapter.Fill(aFindToolHistoryByDateRangeDataSet.FindToolHistoryByDateRange, datStartDate, datEndDate); 
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tool History Class // Find Tool History By Date Range " + Ex.Message);
            }

            return aFindToolHistoryByDateRangeDataSet;
        }
        public bool InsertToolHistory(int intToolKey, int intEmployeeID, int intWarehouseEmployee, string strTransactionNotes)
        {
            bool blnFatalError = false;

            try
            {
                aInsertToolHistoryTableAdapter = new InsertToolHistoryEntryTableAdapters.QueriesTableAdapter();
                aInsertToolHistoryTableAdapter.InsertToolHistory(intToolKey, DateTime.Now, intEmployeeID, intWarehouseEmployee, strTransactionNotes);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tool History Class // Insert Tool History " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public ToolHistoryDataSet GetToolHistoryInfo()
        {
            try
            {
                aToolHistoryDataSet = new ToolHistoryDataSet();
                aToolHistoryTableAdapter = new ToolHistoryDataSetTableAdapters.toolhistoryTableAdapter();
                aToolHistoryTableAdapter.Fill(aToolHistoryDataSet.toolhistory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tool History Class // Get Tool History Info " + Ex.Message);
            }

            return aToolHistoryDataSet;
        }
        public void UpdateToolHistoryDB(ToolHistoryDataSet aToolHistoryDataSet)
        {
            try
            {
                aToolHistoryTableAdapter = new ToolHistoryDataSetTableAdapters.toolhistoryTableAdapter();
                aToolHistoryTableAdapter.Update(aToolHistoryDataSet.toolhistory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tool History Class // Update Tool History DB " + Ex.Message);
            }
        }
    }
}
