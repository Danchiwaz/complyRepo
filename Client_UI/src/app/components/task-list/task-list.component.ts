import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ItemService } from '../../models/task.model';
import { ItemServiceService } from '../../services/compliance-task.service';
import { Category, Priority, Status } from '../../enums/enums';
import { AddTaskComponent } from '../add-task/add-task.component';
import { MenuItem, MessageService, PrimeIcons } from 'primeng/api';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css'],
})
export class TaskListComponent implements OnInit {
  ItemServices: MenuItem[] = [];

  tasks: ItemService[] = [];
  Category = Category;
  Priority = Priority;
  Status = Status;
  isLoading: boolean = false;

  // icons

  // end of icons

  constructor(
    private taskService: ItemServiceService,
    private modalService: NgbModal,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.ItemServices = [
      {
        label: 'New',
        icon: PrimeIcons.PLUS,
      },
    ];
    this.loadTasks();
  }

  loadTasks() {
    this.isLoading = true;
    this.taskService.getTasks().subscribe({
      next: (data) => {
        this.tasks = data;
        this.isLoading = false;
      },
      error: (error) => {
        this.isLoading = false;
      },
    });
  }

  openForm() {
    const modalRef = this.modalService.open(AddTaskComponent, {
      ariaLabelledBy: 'modal-basic-title',
      centered: true,
    });
    modalRef.componentInstance.taskAdded.subscribe((newTask: ItemService) => {
      this.tasks.push(newTask);
    });
  }

  calculateFactorial() {
    this.isLoading = true;
    this.taskService.calculateFactorial().subscribe({
      next: (data) => {
        this.tasks = data;
        this.isLoading = false;
      },
      error: (error) => {
        this.isLoading = false;
      },
    });
  }
}
