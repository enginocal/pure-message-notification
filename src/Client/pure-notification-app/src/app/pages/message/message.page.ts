import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AlertController, ToastController } from '@ionic/angular';
import { MessageService, PushMessage } from 'src/app/services/message.service';


@Component({
  selector: 'app-message',
  templateUrl: './message.page.html',
  styleUrls: ['./message.page.scss'],
})
export class MessagePage {
  push: PushMessage;
  pushMessage: string;
  submitted: boolean;

  constructor(public alertController: AlertController,
    public toastController: ToastController,
    public messageService: MessageService) {
  }


  async ionViewDidEnter() {
    const toast = await this.toastController.create({
      message: 'You can send a new message like Whatsapp',
      duration: 3000
    });
    await toast.present();
  }

  async sendMessage(form: NgForm) {

    this.submitted = true;

    if (form.valid) {


      this.messageService.sendMessage(this.pushMessage).subscribe(data => {
        console.log(data);
      });

      this.pushMessage = '';
      this.submitted = false;

      const toast = await this.toastController.create({
        message: 'Your message has been sent.',
        duration: 2000
      });
      await toast.present();

    }
    // pushMessage=form.
  }

}
