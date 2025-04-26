namespace UMS.UI.Test.OnlinePortal.Areas.Common
{
    public static class PortalCommonElement
    {
        public static By AddCourseMenu => By.XPath("//*[@href='/Course/Programs']");

        public static By SuccessAlertMessage => By.XPath("//*[@class='alert alert-success']");
        public static By FailureAlertMessage => By.XPath("//*[@class='alert alert-danger']");
        public static By ShowProcessing => By.XPath("//*[contains(text(), 'Processing...')]");

    }
}
