import { Component, OnInit } from '@angular/core';

import { DataService } from '../data.service';
import { User } from '../shared/user';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  private users: User[] = [];

  constructor(private dataService: DataService) {

    this.dataService.getUsers().subscribe((response: User[]) => {
      this.users = response;
    });

  }

  ngOnInit() {

  }
}
