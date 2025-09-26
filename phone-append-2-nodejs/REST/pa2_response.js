/**
 * Response from PhoneAppend API, containing phone information and potential error.
 */
export class PA2Response {
    constructor(data = {}) {
        this.PhoneInfo = data.PhoneInfo ? new PhoneInfo(data.PhoneInfo) : null;
        this.Error = data.Error ? new Error(data.Error) : null;
    }

    toString() {
        return `PA2Response: PhoneInfo = ${this.PhoneInfo ? this.PhoneInfo.toString() : 'null'}, Error = ${this.Error ? this.Error.toString() : 'null'}`;
    }
}

/**
 * Phone information for API responses.
 */
export class PhoneInfo {
    constructor(data = {}) {
        this.Phone = data.Phone;
        this.Name = data.Name;
        this.Address = data.Address;
        this.City = data.City;
        this.State = data.State;
        this.PostalCode = data.PostalCode;
        this.IsResidential = data.IsResidential;
        this.Certainty = data.Certainty;
        this.LineType = data.LineType;
    }

    toString() {
        return `PhoneInfo: Phone = ${this.Phone}, Name = ${this.Name}, Address = ${this.Address}, City = ${this.City}, State = ${this.State}, PostalCode = ${this.PostalCode}, IsResidential = ${this.IsResidential}, Certainty = ${this.Certainty}, LineType = ${this.LineType}`;
    }
}

/**
 * Error object for API responses.
 */
export class Error {
    constructor(data = {}) {
        this.Type = data.Type;
        this.TypeCode = data.TypeCode;
        this.Desc = data.Desc;
        this.DescCode = data.DescCode;
    }

    toString() {
        return `Error: Type = ${this.Type}, TypeCode = ${this.TypeCode}, Desc = ${this.Desc}, DescCode = ${this.DescCode}`;
    }
}

export default PA2Response;