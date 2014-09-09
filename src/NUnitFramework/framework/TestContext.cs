﻿// ***********************************************************************
// Copyright (c) 2011 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using System.IO;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace NUnit.Framework
{
    /// <summary>
    /// Provide the context information of the current test.
    /// This is an adapter for the internal ExecutionContext
    /// class, hiding the internals from the user test.
    /// </summary>
    public class TestContext
    {
        private readonly TestExecutionContext _testExecutionContext;
        private TestAdapter _test;
        private ResultAdapter _result;

        #region Constructor

        /// <summary>
        /// Construct a TestContext for an ExecutionContext
        /// </summary>
        /// <param name="testExecutionContext">The ExecutionContext to adapt</param>
        public TestContext(TestExecutionContext testExecutionContext)
        {
            _testExecutionContext = testExecutionContext;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the current test context. This is created
        /// as needed. The user may save the context for
        /// use within a test, but it should not be used
        /// outside the test for which it is created.
        /// </summary>
        public static TestContext CurrentContext
        {
            get { return new TestContext(TestExecutionContext.CurrentContext); }
        }

        /// <summary>
        /// Gets a TextWriter that will send output to the current test result.
        /// </summary>
        public static TextWriter Out
        {
            get { return TestExecutionContext.CurrentContext.CurrentResult.OutWriter; }
        }

        /// <summary>
        /// Get a representation of the current test.
        /// </summary>
        public TestAdapter Test
        {
            get { return _test ?? (_test = new TestAdapter(_testExecutionContext.CurrentTest)); }
        }

        /// <summary>
        /// Gets a Representation of the TestResult for the current test. 
        /// </summary>
        public ResultAdapter Result
        {
            get { return _result ?? (_result = new ResultAdapter(_testExecutionContext.CurrentResult)); }
        }

#if !NETCF && !SILVERLIGHT
        /// <summary>
        /// Gets the directory containing the current test assembly.
        /// </summary>
        public string TestDirectory
        {
            get { return AssemblyHelper.GetDirectoryName(_testExecutionContext.CurrentTest.FixtureType.Assembly); }
        }
#endif

        /// <summary>
        /// Gets the directory to be used for outputing files created
        /// by this test run.
        /// </summary>
        public string WorkDirectory
        {
            get { return _testExecutionContext.WorkDirectory; }
        }

        /// <summary>
        /// Gets the random generator.
        /// </summary>
        /// <value>
        /// The random generator.
        /// </value>
        public RandomGenerator Random
        {
            get { return _testExecutionContext.RandomGenerator; }
        }

        #endregion

        #region Static Methods

        /// <summary>Write the string representation of a boolean value to the current result</summary>
        public static void Write(bool value) { Out.Write(value); }

        /// <summary>Write a char to the current result</summary>
        public static void Write(char value) { Out.Write(value); }

        /// <summary>Write a char array to the current result</summary>
        public static void Write(char[] value) { Out.Write(value); }

        /// <summary>Write the string representation of a double to the current result</summary>
        public static void Write(double value) { Out.Write(value); }

        /// <summary>Write the string representation of an Int32 value to the current result</summary>
        public static void Write(Int32 value) { Out.Write(value); }

        /// <summary>Write the string representation of an Int64 value to the current result</summary>
        public static void Write(Int64 value) { Out.Write(value); }

        /// <summary>Write the string representation of a decimal value to the current result</summary>
        public static void Write(decimal value) { Out.Write(value); }

        /// <summary>Write the string representation of an object to the current result</summary>
        public static void Write(object value) { Out.Write(value); }

        /// <summary>Write the string representation of a Single value to the current result</summary>
        public static void Write(Single value) { Out.Write(value); }

        /// <summary>Write a string to the current result</summary>
        public static void Write(string value) { Out.Write(value); }

        /// <summary>Write the string representation of a UInt32 value to the current result</summary>
        [CLSCompliant(false)]
        public static void Write(UInt32 value) { Out.Write(value); }

        /// <summary>Write the string representation of a UInt64 value to the current result</summary>
        [CLSCompliant(false)]
        public static void Write(UInt64 value) { Out.Write(value); }

        /// <summary>Write a formatted string to the current result</summary>
        public static void Write(string format, object arg1) { Out.Write(format, arg1); }

        /// <summary>Write a formatted string to the current result</summary>
        public static void Write(string format, object arg1, object arg2) { Out.Write(format, arg1, arg2); }

        /// <summary>Write a formatted string to the current result</summary>
        public static void Write(string format, object arg1, object arg2, object arg3) { Out.Write(format, arg1, arg2, arg3); }

        /// <summary>Write a formatted string to the current result</summary>
        public static void Write(string format, params object[] args) { Out.Write(format, args); }

        /// <summary>Write a line terminator to the current result</summary>
        public static void WriteLine() { Out.WriteLine(); }

        /// <summary>Write the string representation of a boolean value to the current result followed by a line terminator</summary>
        public static void WriteLine(bool value) { Out.WriteLine(value); }

        /// <summary>Write a char to the current result followed by a line terminator</summary>
        public static void WriteLine(char value) { Out.WriteLine(value); }

        /// <summary>Write a char array to the current result followed by a line terminator</summary>
        public static void WriteLine(char[] value) { Out.WriteLine(value); }

        /// <summary>Write the string representation of a double to the current result followed by a line terminator</summary>
        public static void WriteLine(double value) { Out.WriteLine(value); }

        /// <summary>Write the string representation of an Int32 value to the current result followed by a line terminator</summary>
        public static void WriteLine(Int32 value) { Out.WriteLine(value); }

        /// <summary>Write the string representation of an Int64 value to the current result followed by a line terminator</summary>
        public static void WriteLine(Int64 value) { Out.WriteLine(value); }

        /// <summary>Write the string representation of a decimal value to the current result followed by a line terminator</summary>
        public static void WriteLine(decimal value) { Out.WriteLine(value); }

        /// <summary>Write the string representation of an object to the current result followed by a line terminator</summary>
        public static void WriteLine(object value) { Out.WriteLine(value); }

        /// <summary>Write the string representation of a Single value to the current result followed by a line terminator</summary>
        public static void WriteLine(Single value) { Out.WriteLine(value); }

        /// <summary>Write a string to the current result followed by a line terminator</summary>
        public static void WriteLine(string value) { Out.WriteLine(value); }

        /// <summary>Write the string representation of a UInt32 value to the current result followed by a line terminator</summary>
        [CLSCompliant(false)]
        public static void WriteLine(UInt32 value) { Out.WriteLine(value); }

        /// <summary>Write the string representation of a UInt64 value to the current result followed by a line terminator</summary>
        [CLSCompliant(false)]
        public static void WriteLine(UInt64 value) { Out.WriteLine(value); }

        /// <summary>Write a formatted string to the current result followed by a line terminator</summary>
        public static void WriteLine(string format, object arg1) { Out.WriteLine(format, arg1); }

        /// <summary>Write a formatted string to the current result followed by a line terminator</summary>
        public static void WriteLine(string format, object arg1, object arg2) { Out.WriteLine(format, arg1, arg2); }

        /// <summary>Write a formatted string to the current result followed by a line terminator</summary>
        public static void WriteLine(string format, object arg1, object arg2, object arg3) { Out.WriteLine(format, arg1, arg2, arg3); }

        /// <summary>Write a formatted string to the current result followed by a line terminator</summary>
        public static void WriteLine(string format, params object[] args) { Out.WriteLine(format, args); }

        #endregion

        #region Nested TestAdapter Class

        /// <summary>
        /// TestAdapter adapts a Test for consumption by
        /// the user test code.
        /// </summary>
        public class TestAdapter
        {
            private readonly Test _test;

            #region Constructor

            /// <summary>
            /// Construct a TestAdapter for a Test
            /// </summary>
            /// <param name="test">The Test to be adapted</param>
            public TestAdapter(Test test)
            {
                _test = test;
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets the unique Id of a test
            /// </summary>
            public int ID
            {
                get { return _test.Id; }
            }

            /// <summary>
            /// The name of the test, which may or may not be
            /// the same as the method name.
            /// </summary>
            public string Name
            {
                get { return _test.Name; }
            }
            
            /// <summary>
            /// The name of the method representing the test.
            /// </summary>
            public string MethodName
            {
                get
                {
                    return _test is TestMethod
                        ? _test.Method.Name
                        : null;
                }
            }

            /// <summary>
            /// The FullName of the test
            /// </summary>
            public string FullName
            {
                get { return _test.FullName; }
            }

            /// <summary>
            /// The properties of the test.
            /// </summary>
            public IPropertyBag Properties
            {
                get { return _test.Properties; }
            }

            #endregion
        }

        #endregion

        #region Nested ResultAdapter Class

        /// <summary>
        /// ResultAdapter adapts a TestResult for consumption by
        /// the user test code.
        /// </summary>
        public class ResultAdapter
        {
            private readonly TestResult _result;

            #region Constructor

            /// <summary>
            /// Construct a ResultAdapter for a TestResult
            /// </summary>
            /// <param name="result">The TestResult to be adapted</param>
            public ResultAdapter(TestResult result)
            {
                _result = result;
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets a ResultState representing the outcome of the test.
            /// </summary>
            public ResultState Outcome
            {
                get { return _result.ResultState; }
            }

            /// <summary>
            /// Gets the message associated with a test
            /// failure or with not running the test
            /// </summary>
            public string Message
            {
                get { return _result.Message; }
            }

            /// <summary>
            /// Gets any stacktrace associated with an
            /// error or failure. Not available in
            /// the Compact Framework 1.0.
            /// </summary>
            public virtual string StackTrace
            {
                get { return _result.StackTrace; }
            }

            /// <summary>
            /// Gets the number of test cases that failed
            /// when running the test and all its children.
            /// </summary>
            public int FailCount
            {
                get { return _result.FailCount; }
            }

            /// <summary>
            /// Gets the number of test cases that passed
            /// when running the test and all its children.
            /// </summary>
            public int PassCount
            {
                get { return _result.PassCount; }
            }

            /// <summary>
            /// Gets the number of test cases that were skipped
            /// when running the test and all its children.
            /// </summary>
            public int SkipCount
            {
                get { return _result.SkipCount; }
            }

            /// <summary>
            /// Gets the number of test cases that were inconclusive
            /// when running the test and all its children.
            /// </summary>
            public int InconclusiveCount
            {
                get { return _result.InconclusiveCount; }
            }

            #endregion
        }
        
        #endregion
    }
}
