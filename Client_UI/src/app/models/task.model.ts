import { Category, Priority, Status } from '../enums/enums';

export interface ItemService {
  taskID: number;
  taskIDFactorial: number | null;
  category: Category;
  description?: string;
  dueDate: Date;
  priority: Priority;
  status: Status;
}
