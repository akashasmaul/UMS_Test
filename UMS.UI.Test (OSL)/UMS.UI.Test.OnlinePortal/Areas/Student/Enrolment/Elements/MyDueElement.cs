namespace UMS.UI.Test.OnlinePortal.Areas.Student.Enrolment.Elements
{
    class MyDueElement
    {
        public static By DuePaymentMenu => By.XPath("//a[@href='/Enrolment/MyDue']");
        public static By PayNowButton => By.XPath("//a[normalize-space()='Pay Now']");
        public static By DueAmount => By.XPath("//input[@id='DueAmount']");
        public static By PaymentAmount => By.XPath("//input[@id='PaymentAmount']");
        public static By BkashWebPayment => By.XPath("//input[@class='radio-bkash' and @name='SslCommerzPaymentMethod']");
        public static By IsAgreeTermsAndCondition => By.XPath("//input[@id='IsAgreeTermsAndCondition']");
        public static By ProceedToPayButon => By.XPath("//button[@id='btnSubmit']");
        public static By SuccessButton => By.XPath("//input[@value='Success']");
        public static By SuccessMessage => By.XPath("//h2[normalize-space()='CONGRATULATIONS!']");
    }
}