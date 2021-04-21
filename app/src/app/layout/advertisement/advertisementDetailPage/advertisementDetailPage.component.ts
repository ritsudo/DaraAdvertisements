import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { switchMap } from 'rxjs/operators';
import { Advertisement } from 'src/app/Dtos/advertisement';
import { AdvertisementService } from 'src/app/services/advertisements.service';
import { ImageService } from 'src/app/services/image.service';
import {ChatService} from '../../../services/chat.service';

@UntilDestroy()
@Component({
  selector: 'app-advertisementDetailPage',
  templateUrl: './advertisementDetailPage.component.html',
  styleUrls: ['./advertisementDetailPage.component.scss'],
  providers: [
    AdvertisementService
  ]
})
export class AdvertisementDetailPageComponent implements OnInit {
    public id = 0;
    public advertisement: Advertisement | null = null;
    images: any[];
    imageValues: string[];


    constructor(
      private route: ActivatedRoute,
      private advertisementService: AdvertisementService,
      private imageService: ImageService,
      private chatService: ChatService,
      private router: Router
      ){
      this.advertisement = {} as Advertisement;
      this.images = [];
      this.imageValues = [];
    }

    changeImage(i: number) {
      this.imageValues[0] = this.imageValues[i];
    }

    ngOnInit() {
        window.scrollTo(0, 0);
        this.route.paramMap.pipe(
            switchMap(params => params.getAll('id'))
        )
        .pipe(untilDestroyed(this))
        .subscribe(data=> this.id = +data);

        this.advertisementService.getAdvertisementById(this.id)
            .subscribe((data: Advertisement) => {
              this.advertisement = data;
              this.images = data.images;

              for (let i = 0; i < this.images.length; i++) {
                this.imageService.getImageById(this.images[i].id)
                .pipe(untilDestroyed(this))
                .subscribe((data: any) => {
                  this.imageValues[i + 1] = 'data:image/jpeg;base64,' + data.imageBlob;
                  if (i === 0) {
                    this.imageValues[0] = this.imageValues[1]
                  }
                });
              }
            });

    }

    onCreateChat(){
      this.chatService.createChat(this.id)
        .subscribe((r) => {
          this.router.navigateByUrl('/chats');
        });
    }

}
