import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Category, Priority, Status } from 'src/app/enums/enums';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap'; // <-- Import NgbActiveModal
import { ItemServiceService } from 'src/app/services/compliance-task.service';
import { ItemServiceRequest } from 'src/app/models/task.request';
import { ItemService } from 'src/app/models/task.model';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css'],
})
export class AddTaskComponent {
  category = new FormControl('', Validators.required);
  description = new FormControl('');
  dueDate = new FormControl('', Validators.required);
  priority = new FormControl('', Validators.required);
  status = new FormControl('', Validators.required);
  error_message: string = '';

  taskForm = new FormGroup({
    category: this.category,
    description: this.description,
    dueDate: this.dueDate,
    priority: this.priority,
    status: this.status,
  });

  CategoryEnum = Object.values(Category).filter((value) =>
    isNaN(Number(value))
  );
  PriorityEnum = Object.values(Priority).filter((value) =>
    isNaN(Number(value))
  );
  StatusEnum = Object.values(Status).filter((value) => isNaN(Number(value)));

  @Output() taskAdded = new EventEmitter<ItemService>();

  constructor(
    public activeModal: NgbActiveModal,
    private taskService: ItemServiceService,
    private messageService: MessageService
  ) {}

  onSubmit() {
    if (this.taskForm.valid) {
      const formValues = this.taskForm.value;

      let dueDateValue: Date | undefined;

      if (formValues.dueDate) {
        dueDateValue = new Date(formValues.dueDate);
      }

      const newTask: ItemServiceRequest = {
        category: Category[formValues.category as keyof typeof Category],
        description: formValues.description || undefined,
        dueDate: dueDateValue,
        priority: Priority[formValues.priority as keyof typeof Priority],
        status: Status[formValues.status as keyof typeof Status],
      };

      this.taskService.addTask(newTask).subscribe({
        next: (data) => {
          this.taskAdded.emit(data);
          this.closeModal();
        },
        error: (err) => (this.error_message = err.message),
        complete: () => this.closeModal(),
      });
    }
    this.showToast();
  }

  showToast() {
    return this.messageService.add({
      key: 'toast1',
      severity: 'warn',
      summary: 'Error',
      detail: 'Check error in form',
    });
  }
  closeModal() {
    this.activeModal.close();
  }
}
