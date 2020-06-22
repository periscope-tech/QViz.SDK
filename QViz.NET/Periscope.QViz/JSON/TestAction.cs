using System;
using System.Collections.Generic;
using System.Text;

namespace Periscope.QViz.JSON
{
    /// <summary>
	/// JSON Model for API Test Case and its actions
	/// </summary>
    public class TestAction
    {
        /// <summary>
		/// Identifier of the Test API mapping Object
		/// </summary>
        public string TestActionId { get; set; }
        /// <summary>
        /// Identifier of the Test case Object
        /// </summary>
        public string TestCaseId { get; set; }
        /// <summary>
        /// Serial number for test case action mapping 
        /// </summary>
        public int? SrNo { get; set; }
        /// <summary>
        /// Mapping Action Object
        /// </summary>
        public Action Action { get; set; }

    }
}
