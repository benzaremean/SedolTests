Feature: Sedol Checker Validation
    
Scenario Outline: Null, empty string or string other than 7 characters long
    # I am assuming that from UI it would be impossible to test the null input string scenario
    Given the following sedol values:
        | InputString   | IsValidSedol   | IsUserDefined   |
        | <InputString> | <IsValidSedol> | <IsUserDefined> |
    Then the validation message should be 'Input string was not 7-characters long.'
    
    Examples:
        | InputString   | IsValidSedol   | IsUserDefined   | 
        |               | False          | False           |
        | 12            | False          | False           | 
        | 123456789     | False          | False           |


 Scenario: Invalid non user define SEDOL
    Given the following sedol values:
        | InputString   | IsValidSedol   | IsUserDefined   |
        | 1234567       | False          | False           |
    Then the validation message should be 'Checksum digit does not agree with the rest of the input'



Scenario Outline: Valid non user define SEDOL
    Given the following sedol values:
        | InputString   | IsValidSedol   | IsUserDefined   |
        | <InputString> | <IsValidSedol> | <IsUserDefined> |
    Then the validation message should be ''
    
    Examples:
        | InputString   | IsValidSedol   | IsUserDefined   | 
        | 0709954       | True           | False           |
        | B0YBKJ7       | True           | False           |



Scenario Outline: Invalid user defined SEDOL
    Given the following sedol values:
        | InputString   | IsValidSedol   | IsUserDefined   |
        | <InputString> | <IsValidSedol> | <IsUserDefined> |
    Then the validation message should be 'Checksum digit does not agree with the rest of the input'
    
    Examples:
        | InputString   | IsValidSedol   | IsUserDefined |
        | 9123451       | False          | True          |
        | 9ABCDE8       | False          | True          |



Scenario Outline: Valid user defined SEDOL
    Given the following sedol values:
        | InputString   | IsValidSedol   | IsUserDefined   |
        | <InputString> | <IsValidSedol> | <IsUserDefined> |
    Then the validation message should be ''
    
    Examples:
        | InputString   | IsValidSedol   | IsUserDefined | 
        | 9123458       | True           | True          |
        | 9ABCDE1       | True           | True          |

       
 