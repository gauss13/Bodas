import { Component } from '@angular/core';
import { Globalx } from './config/global';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ClientApp';

  constructor(private glb: Globalx)
  {

  }

}
