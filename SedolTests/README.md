# SEDOL VALIDATION CHECKER TESTS

### Libraries

I had to write the tests on my macOS Sierra 10.12 machine using visual studio for mac
and this meant I was limited to using .NET Core 2.0

The tests were written in BDD feature file using Specflow version 2.3.1 which meant I had to use a much older 
version of NUnit version 2.6.4 due to compatibility issues with newer versions. 

For driving the UI I used Selenium.Webdriver version 3.10.0, Selenium.WebDriver.ChromeDriver 
version 2.36.0 and Selenium.Support version 3.10.0.


### Findings and Recommendations

From a usability perspective, I have a few recommendations not in order of priority:

1. Is Valid Sedol and Is User Defined checkbox inputs should be radio options as that is better for form control for choice.
   It will not be clear to users that not selecting checkbox means false.

2. Sedol Input text box does not have a label. I actually thought it was an alignment issue initially, until 
   I realised that the 'Sedol Input' p tag was used to replay users text input after form submission.

3. When Sedol input string is not 7 characters, I would recommend that the error message is aligned inline or just underneath
   the input so that user can correct easily as it would be more obvious.

4. Validation Error Messages are not very clear as the font is black. I would recommend it be changed to red.

5. Would also recommend that when the inputs are valid that we have a success message rather than an empty string.

6. Would also recommend that the form submission is done using AJAX so that new page load is not required.

7. The background colour of the 'Is Valid Sedol' and 'Is User Defined' makes it difficult to read the text. 
   I am expecting that users with impaired vision will struggle to read the label text.

8. Would also be great to distinguish optional and required fields. In this case, I presume all the fields are mandatory.

9. Would recommend also that we add test data attributes or ids to the elements to make the automation tests more
   robust and reliable. I unfortunately had to use xpath as location strategy for the check boxes. 

### Test Run Results

I have written the tests to cover the Acceptance Criteria provided and all test pass apart from the following:

i. Invalid non user define SEDOL (2 scenarios)
ii. Invalid user defined SEDOL (1 scenario)

The issue is that the expected validation message 'Checksum digit does not agree with the rest of the input'
is not same as the actual 'Checksum digit does not agree with the first 6 characters.'





