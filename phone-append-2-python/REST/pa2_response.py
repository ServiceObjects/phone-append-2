from dataclasses import dataclass
from typing import Optional, List

# Input parameters for the PhoneAppend API call.
@dataclass
class PhoneAppendInput:
    FullName: Optional[str] = None
    FirstName: Optional[str] = None
    LastName: Optional[str] = None
    Address: Optional[str] = None
    City: Optional[str] = None
    State: Optional[str] = None
    PostalCode: Optional[str] = None
    IsBusiness: Optional[str] = None
    LicenseKey: Optional[str] = None

    def __str__(self) -> str:
        return (f"PhoneAppendInput: FullName={self.FullName}, FirstName={self.FirstName}, "
                f"LastName={self.LastName}, Address={self.Address}, City={self.City}, "
                f"State={self.State}, PostalCode={self.PostalCode}, "
                f"IsBusiness={self.IsBusiness}, LicenseKey={self.LicenseKey}")

# Error object for API responses.
@dataclass
class Error:
    Type: Optional[str] = None
    TypeCode: Optional[str] = None
    Desc: Optional[str] = None
    DescCode: Optional[str] = None

    def __str__(self) -> str:
        return (f"Error: Type={self.Type}, TypeCode={self.TypeCode}, "
                f"Desc={self.Desc}, DescCode={self.DescCode}")

# Phone information for API responses.
@dataclass
class PhoneInfo:
    Phone: Optional[str] = None
    Name: Optional[str] = None
    Address: Optional[str] = None
    City: Optional[str] = None
    State: Optional[str] = None
    PostalCode: Optional[str] = None
    IsResidential: Optional[str] = None
    Certainty: Optional[str] = None
    LineType: Optional[str] = None
    Debug: Optional[str] = None

    def __str__(self) -> str:
        return (f"PhoneInfo: Phone={self.Phone}, Name={self.Name}, "
                f"Address={self.Address}, City={self.City}, State={self.State}, "
                f"PostalCode={self.PostalCode}, IsResidential={self.IsResidential}, "
                f"Certainty={self.Certainty}, LineType={self.LineType}, Debug={self.Debug}")

# Response from PhoneAppend API, containing phone information and potential error.
@dataclass
class PA2Response:
    PhoneInfo: Optional['PhoneInfo'] = None
    Error: Optional['Error'] = None

    def __str__(self) -> str:
        phone_info = str(self.PhoneInfo) if self.PhoneInfo else 'None'
        error = str(self.Error) if self.Error else 'None'
        return f"PA2Response: PhoneInfo={phone_info}, Error={error}"