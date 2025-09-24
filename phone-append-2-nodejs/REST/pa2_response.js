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
        this.Phone = data.Phone || null;
        this.Name = data.Name || null;
        this.Address = data.Address || null;
        this.City = data.City || null;
        this.State = data.State || null;
        this.PostalCode = data.PostalCode || null;
        this.IsResidential = data.IsResidential || null;
        this.Certainty = data.Certainty || null;
        this.LineType = data.LineType || null;
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
        this.Type = data.Type || null;
        this.TypeCode = data.TypeCode || null;
        this.Desc = data.Desc || null;
        this.DescCode = data.DescCode || null;
    }

    toString() {
        return `Error: Type = ${this.Type}, TypeCode = ${this.TypeCode}, Desc = ${this.Desc}, DescCode = ${this.DescCode}`;
    }
}

export default PA2Response;