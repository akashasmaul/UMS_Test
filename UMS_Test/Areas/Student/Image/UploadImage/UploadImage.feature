Feature: UploadImage

@NeedsLogin
@DataSource:../../../../TestData/Student/Image/UploadImage/ImageData.xlsx @DataSet:Sheet1
Scenario: Image Upload
	Given Go to the Upload Image Page
	When Based on Image Type "<ImageType>", Browse "<Path>" and Select Images 
	And Check Allow Over Write Checkbox as "<OverWrite>"
	And Click the Upload Button
	Then Image Upload Should be Succeed
	Then Click Clear Buton and Verify
