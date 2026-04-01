import { Component, signal, inject, OnInit} from '@angular/core';
import { provideHttpClient } from '@angular/common/http';
import { RouterOutlet } from '@angular/router';
import { SportService } from './sport-service';
import {FormGroup, FormControl, ReactiveFormsModule, Validators} from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ReactiveFormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  sportService = inject(SportService);

  ngOnInit(): void {
    this.sportService.getEvents().subscribe(events => this.events = events);
  }

  events: any[] = [];
}