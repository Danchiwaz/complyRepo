import { Category, Priority, Status } from '../enums/enums';

export interface ItemServiceRequest {
  category: Category;
  description: string | undefined;
  dueDate: Date | undefined;
  priority: Priority;
  status: Status;
}
