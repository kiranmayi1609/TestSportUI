import { Injectable } from "@angular/core";
import { HttpClient,HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
    providedIn:'root'
})

export class BadmintonApiService{
    [x: string]: any;
    private apiUrl='https://badminton-devs.p.rapidapi.com/countries?limit=50&lang=en&id=eq.1&offset=0&alpha=eq.CA'
    private headers=new HttpHeaders({
        'x-rapidapi-key':'01e9748ae5msh19ba1805320299cp107c61jsndf918013e813',
        'x-rapidapi-host':'badminton-devs.p.rapidapi.com'
    });

    constructor(private http:HttpClient) {}

    getCountries():Observable<any>{
        return this.http.get<any>(this.apiUrl,{headers:this.headers});
    }
}