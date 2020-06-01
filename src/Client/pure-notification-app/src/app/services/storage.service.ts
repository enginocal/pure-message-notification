import { Injectable } from '@angular/core';
import { NativeStorage } from '@ionic-native/native-storage/ngx';


@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor(private storage: NativeStorage) {

  }

  saveToken(token: string) {
    return this.storage.setItem("myDeviceToken", token)
      //  .then(() => console.log('token store in service:' + token));
      .then(
        () => console.log('Stored item!' + token),
        error => console.error('Error storing item', error)
      );

  }

  async getToken() {
    var token = '';
    console.log("getToken");
    await this.storage.getItem("myDeviceToken").then(data => {
      console.log("getToken storage service" + data);
      token = data;
    }).finally(() => {
      
    });
    console.log("getToken finish" + token);
    return token;
  }

}
