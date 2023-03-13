/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.10.9.0 (NJsonSchema v10.4.1.0 (Newtonsoft.Json v11.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

export class GeneratedBackendProxy {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : <any>window;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    /**
     * @return Success
     */
    getAllMonthlyExpenses(): Promise<MonthlyExpenseApiModel[]> {
        let url_ = this.baseUrl + "/monthlyexpenses";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetAllMonthlyExpenses(_response);
        });
    }

    protected processGetAllMonthlyExpenses(response: Response): Promise<MonthlyExpenseApiModel[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <MonthlyExpenseApiModel[]>JSON.parse(_responseText, this.jsonParseReviver);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<MonthlyExpenseApiModel[]>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    postMonthlyExpense(body: MonthlyExpensePostApiModel | undefined): Promise<MonthlyExpenseApiModel> {
        let url_ = this.baseUrl + "/monthlyexpenses";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ = <RequestInit>{
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processPostMonthlyExpense(_response);
        });
    }

    protected processPostMonthlyExpense(response: Response): Promise<MonthlyExpenseApiModel> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <MonthlyExpenseApiModel>JSON.parse(_responseText, this.jsonParseReviver);
            return result200;
            });
        } else if (status === 400) {
            return response.text().then((_responseText) => {
            let result400: any = null;
            result400 = _responseText === "" ? null : <ProblemDetails>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("Bad Request", status, _responseText, _headers, result400);
            });
        } else if (status === 409) {
            return response.text().then((_responseText) => {
            let result409: any = null;
            result409 = _responseText === "" ? null : <ProblemDetails>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("Conflict", status, _responseText, _headers, result409);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<MonthlyExpenseApiModel>(<any>null);
    }

    /**
     * @return Success
     */
    getMonthlyExpense(year: number, month: number): Promise<MonthlyExpenseApiModel> {
        let url_ = this.baseUrl + "/monthlyexpenses/{year}/{month}";
        if (year === undefined || year === null)
            throw new Error("The parameter 'year' must be defined.");
        url_ = url_.replace("{year}", encodeURIComponent("" + year));
        if (month === undefined || month === null)
            throw new Error("The parameter 'month' must be defined.");
        url_ = url_.replace("{month}", encodeURIComponent("" + month));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetMonthlyExpense(_response);
        });
    }

    protected processGetMonthlyExpense(response: Response): Promise<MonthlyExpenseApiModel> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <MonthlyExpenseApiModel>JSON.parse(_responseText, this.jsonParseReviver);
            return result200;
            });
        } else if (status === 404) {
            return response.text().then((_responseText) => {
            let result404: any = null;
            result404 = _responseText === "" ? null : <ProblemDetails>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("Not Found", status, _responseText, _headers, result404);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<MonthlyExpenseApiModel>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    putMonthlyExpense(year: number, month: number, body: MonthlyExpensePutApiModel | undefined): Promise<MonthlyExpenseApiModel> {
        let url_ = this.baseUrl + "/monthlyexpenses/{year}/{month}";
        if (year === undefined || year === null)
            throw new Error("The parameter 'year' must be defined.");
        url_ = url_.replace("{year}", encodeURIComponent("" + year));
        if (month === undefined || month === null)
            throw new Error("The parameter 'month' must be defined.");
        url_ = url_.replace("{month}", encodeURIComponent("" + month));
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ = <RequestInit>{
            body: content_,
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processPutMonthlyExpense(_response);
        });
    }

    protected processPutMonthlyExpense(response: Response): Promise<MonthlyExpenseApiModel> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <MonthlyExpenseApiModel>JSON.parse(_responseText, this.jsonParseReviver);
            return result200;
            });
        } else if (status === 400) {
            return response.text().then((_responseText) => {
            let result400: any = null;
            result400 = _responseText === "" ? null : <ProblemDetails>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("Bad Request", status, _responseText, _headers, result400);
            });
        } else if (status === 404) {
            return response.text().then((_responseText) => {
            let result404: any = null;
            result404 = _responseText === "" ? null : <ProblemDetails>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("Not Found", status, _responseText, _headers, result404);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<MonthlyExpenseApiModel>(<any>null);
    }

    /**
     * @return Success
     */
    deleteMonthlyExpense(year: number, month: number): Promise<void> {
        let url_ = this.baseUrl + "/monthlyexpenses/{year}/{month}";
        if (year === undefined || year === null)
            throw new Error("The parameter 'year' must be defined.");
        url_ = url_.replace("{year}", encodeURIComponent("" + year));
        if (month === undefined || month === null)
            throw new Error("The parameter 'month' must be defined.");
        url_ = url_.replace("{month}", encodeURIComponent("" + month));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "DELETE",
            headers: {
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processDeleteMonthlyExpense(_response);
        });
    }

    protected processDeleteMonthlyExpense(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            return;
            });
        } else if (status === 404) {
            return response.text().then((_responseText) => {
            let result404: any = null;
            result404 = _responseText === "" ? null : <ProblemDetails>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("Not Found", status, _responseText, _headers, result404);
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(<any>null);
    }
}

export interface MonthlyExpenseApiModel {
    id: string;
    year: number;
    month: number;
    netIncomePartner1: number;
    netIncomePartner2: number;
    expenseFixed: number;
    expenseExtra: number;
    expenseSaving: number;
    expenseGroceries: number;
}

export interface MonthlyExpensePostApiModel {
    year: number;
    month: number;
    netIncomePartner1: number;
    netIncomePartner2: number;
    expenseFixed: number;
    expenseExtra: number;
    expenseSaving: number;
    expenseGroceries: number;
}

export interface MonthlyExpensePutApiModel {
    netIncomePartner1: number;
    netIncomePartner2: number;
    expenseFixed: number;
    expenseExtra: number;
    expenseSaving: number;
    expenseGroceries: number;
}

export interface ProblemDetails {
    type?: string | null;
    title?: string | null;
    status?: number | null;
    detail?: string | null;
    instance?: string | null;
}

export class SwaggerException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new SwaggerException(message, status, response, headers, null);
}