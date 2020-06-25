using System;
using System.Collections.Generic;
using System.Text;

namespace Periscope.QViz.JSON
{
    /// <summary>
    /// QViz custom response object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QVizResponseObject<T>
    {
        /// <summary>
        /// 'Message' property will hold custom message  
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     {
        ///        "message": "Test case created successfully"         
        ///     }
        /// </remarks>
        public string Message { get; set; }
        /// <summary>
        /// 'Value' property will hold instance or respective API model  
        /// </summary>
        public T Value { get; set; }
    }
}
