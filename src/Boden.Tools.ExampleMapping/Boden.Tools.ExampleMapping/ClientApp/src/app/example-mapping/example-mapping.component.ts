import { Component } from '@angular/core';

@Component({
  selector: 'example-mapping',
  templateUrl: './example-mapping.component.html',
  styleUrls: ['./example-mapping.component.css']
})
export class ExampleMappingComponent {
  title: string;

  constructor() {
    this.title = 'Hello, World!';
  }
}
