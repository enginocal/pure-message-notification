import { Component, OnInit } from '@angular/core';
import { MessageService, PushMessage } from 'src/app/services/message.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-message-list',
  templateUrl: './message-list.page.html',
  styleUrls: ['./message-list.page.scss'],
})
export class MessageListPage {

  messageList: PushMessage[] = [];
  isFetching = false;
  private _messageListSub: Subscription;
  public _messageService: MessageService;

  constructor(msgService: MessageService) {
    this._messageService = msgService;
  }


  async ionViewWillEnter() {

    this._messageService.getMessages().subscribe(result => {
      this.messageList = result; this.isFetching = false;
    }),
      this.isFetching = true;
    console.log(this.messageList);

  }
  
}

