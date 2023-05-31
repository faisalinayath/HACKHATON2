import { Component, OnInit } from '@angular/core';
import { MenuCardsService } from './service/menu-cards.service';
import { card } from 'src/Models/card.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'hotel';
  cards:card[]=[];
  card:card{
    Id:'',
    DishName:'',
    Description:'',
    DishPrice:''
  }
  

  constructor(private cardsService: MenuCardsService) {}

  ngOnInit(): void {
    this.getAllCards();
  }

  getAllCards() {
    this.cardsService.getAllCards().subscribe(
      (response: any) => {
        this.cards=response;
        console.log(response);
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  onSubmit()
  {
    console.log(this.card);
  }
}
