import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Subject } from 'rxjs';
import { Observable, Subscription, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { StorageService } from './storage.service';
import { NativeStorage } from '@ionic-native/native-storage/ngx';
// import { map } from 'rxjs/operators';



@Injectable({ providedIn: 'root' })
export class MessageService {

  deviceToken: string = 'denemeToken';
  constructor(private httpClient: HttpClient, private nativeStorage: NativeStorage) {

    this.nativeStorage.getItem("myDeviceToken").then(data => {
      this.deviceToken = data;
    });
  }

  baseUrl: string = "https://purenotificationsystemapi.azurewebsites.net/api/pushmessage/";

  sendMessage(message: string): Observable<any> {
    let headers = {};
    // headers.append("Accept", 'application/json');
    // headers.append('Content-Type', 'application/json');

    let postData = new PushMessage();
    postData.textMessage = message;
    postData.deviceToken = this.deviceToken;

    return this.httpClient.post<PushMessage>(this.baseUrl,
      postData, { headers: headers }).pipe(
        catchError(this.handleError<PushMessage>("Send Push Message"))
      );

  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      console.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

  getMessages(): Observable<PushMessage[]> {
    let headers = {};
    var url = this.baseUrl + this.deviceToken;
    console.log("getMessages Url" + url);
    return this.httpClient.get<PushMessage[]>(url, { headers: headers })
      .pipe(tap(_ => console.log('fetched messages')),
        catchError(this.handleError<PushMessage[]>('getMessages', [])));
  }
}


export class PushMessage {
  textMessage: string;
  deviceToken: string;
  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}