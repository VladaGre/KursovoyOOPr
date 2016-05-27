using System;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace GeographHandbook
{
   [Serializable]
    class Hesh : ISerializable 
    {
        int _size, _use;
        eNode []_obj;
        public Hesh() 
        {
            _size = 50;
            _use = 0;
            _obj = new eNode[_size];
        }
        Hesh(int size)
        {
            _size = size;
            _use = 0;
            _obj = new eNode[_size];
        }

        Hesh(Hesh copy)// Конструктор, не используется (для обозримого будущего)
        {
            _size = copy._size;
            _use = copy._use;
            _obj = new eNode[_size];
            for (int t = 0; t < _size; t++)
            {
                _obj[t] = new eNode(copy._obj[t]);
            }
        }

       public bool presence(Element _new)// Проверяет присутствие элемента в хэш-таблице
        {
            eNode temp = Program._main.GetNode(Program._main.Hash(_new.GetName()));// Создание временного элемента для перебора элементов внутри узла 
            while (temp != null)
            {
                if (temp.GetElement().GetName().Equals(_new.GetName()) &&
                    temp.GetElement().GetType().Equals(_new.GetType()) &&
                    temp.GetElement().GetCitizen().Equals(_new.GetCitizen())) return true;
                temp = temp.GetNext();
            }


            return false;
        }

       public bool presenceCM(string _elem)// Проверяет присутствие элемента в хэш-таблице
       {
           eNode temp = Program._main.GetNode(Program._main.Hash(_elem));// Создание временного элемента для перебора элементов внутри узла 
           while (temp != null)
           {
               if (temp.GetElement().GetName().Equals(_elem)) return true;
               temp = temp.GetNext();
           }


           return false;
       }

        public int Hash(string v) // Хэш-функция, один из стандартных алгоритмов
        {
            char[]k = v.ToCharArray();
            int hashsum, i;

            for (hashsum = i = 0;i<k.LongLength; i++)
                hashsum = (hashsum * 31) ^ k[i];
            return (hashsum & 0x7fffffff) % _size;
        }

       public int GetSize()// Возвращает текущий размер таблицы
        {
            return _size;
        }

       public int GetUse()
       {
           return _use;
       }

       public eNode GetNode(int index)// Возвращает элемент таблицы
       {
           return _obj[index];
       }

       public void AddTo(Hesh other)// Добавляет новые элементы из уже существующей хэш-таблицы
        {
           for(int t=0;t<other._size;t++)
           {
               if(other._obj[t]!=null)
               {
                  if(other._obj[t].GetNext()==null) Program._main.AddBase(other._obj[t].GetElement());
                  else
                  {
                      eNode temp = other._obj[t];
                      while(temp!=null)
                      {
                          Program._main.AddBase(temp.GetElement());
                          _use++;
                          temp = temp.GetNext();
                      }
                  }
               }
           }
           if (_use > (_size / 2)) resize(_obj);
        }

       public void AddTo(int size,eNode []obj)// Добавляет новые элементы из уже существующей хэш-таблицы
       {
           for (int t = 0; t < size; t++)
           {
               if (obj[t] != null)
               {
                   if (obj[t].GetNext() == null) Program._main.AddBase(obj[t].GetElement());
                   else
                   {
                       eNode temp = obj[t];
                       while (temp != null)
                       {
                           Program._main.AddBase(temp.GetElement());
                           _use++;
                           temp = temp.GetNext();
                       }
                   }
               }
           }
           if (_use > (_size / 2)) resize(_obj);
       }

       public void Add(Element name)// Добавляет новый элемент в хэш-таблицу
       {
           try
           {
               if (_use > (_size / 2)) resize(_obj);
               if (presence(name)) throw new MyException("Элемент уже внесен в базу!");
               if (_obj[Hash(name.GetName())] == null) _obj[Hash(name.GetName())] = new eNode(name);
               else _obj[Hash(name.GetName())].Add(name);
               _use++;
           }
           catch(MyException exp)
           {
               MessageBoxButtons buttons = MessageBoxButtons.OK;
               MessageBox.Show(exp.GetMessage(), "Ошибка", buttons);
           }

       }

       public void AddBase(Element name)// Добавляет новый элемент в хэш-таблицу
       {   
               if (!presence(name))
               {
                   if (_use > (_size / 2)) resize(_obj);
                   if (_obj[Hash(name.GetName())] == null) _obj[Hash(name.GetName())] = new eNode(name);
                   else _obj[Hash(name.GetName())].Add(name);
                   _use++;
               }
       }

       public Element[] find(string key)// Возвращает все элементы с заданым ключом
       {
           Element[] back;
           int size = 0;
           eNode temp = Program._main.GetNode(Program._main.Hash(key));
           while(temp!=null)
           {
               if (temp.GetElement().GetName().Equals(key)) size++;
               temp = temp.GetNext();
           }
           back = new Element[size];
           temp = Program._main.GetNode(Program._main.Hash(key));
           size = 0;
           while (temp != null)
           {
               if (temp.GetElement().GetName().Equals(key)) back[size++] = temp.GetElement();
               temp = temp.GetNext();
           }
           return back;
       }

       public Country findCountry(string key,Mainland Mparents)
       {
               Country back;
               eNode temp = Program._main.GetNode(Program._main.Hash(key));
               while (temp != null)
               {
                   if (temp.GetElement().GetName().Equals(key))
                       if (temp.GetElement().GetType().Equals("Страна"))
                       {
                           back = (Country)temp.GetElement();
                           if (back.GetMparents() == Mparents) return back;
                       }
                   temp = temp.GetNext();
               }
               return null;
       }

       public Region findRegion(string key,Country Cparents)
       {
           Region back;
           eNode temp = Program._main.GetNode(Program._main.Hash(key));
           while (temp != null)
           {
               if (temp.GetElement().GetName().Equals(key))
                   if (temp.GetElement().GetType().Equals("Область") ||
                       temp.GetElement().GetType().Equals("Штат") ||
                       temp.GetElement().GetType().Equals("Провинция"))
                   {
                       back = (Region)temp.GetElement();
                       if (back.GetCParents() == Cparents) return back;
                   }
               temp = temp.GetNext();
           }
           return null;
       }

       public State findState(string key, Country Cparents)
       {
           State back;
           eNode temp = Program._main.GetNode(Program._main.Hash(key));
           while (temp != null)
           {
               if (temp.GetElement().GetName().Equals(key))
                   if (temp.GetElement().GetType().Equals("Штат"))
                   {
                       back = (State)temp.GetElement();
                       if (back.GetCParents() == Cparents) return back;
                   }
               temp = temp.GetNext();
           }
           return null;
       }

       public City findCity(string key, Region Rparents)
       {
           City back;
           eNode temp = Program._main.GetNode(Program._main.Hash(key));
           while (temp != null)
           {
               if (temp.GetElement().GetName().Equals(key))
                   if (temp.GetElement().GetType().Equals("Город"))
                   {
                       back = (City)temp.GetElement();
                       if (back.GetRparents() == Rparents) return back;
                   }
               temp = temp.GetNext();
           }
           return null;
       }

       public Element onefind(string _key)// Поиск единичного элемента||заменить на поиск материка
        {
            if (_obj[Hash(_key)].GetElement().GetName().Equals(_key))
            return _obj[Hash(_key)].GetElement();
            else
            {
                eNode temp = _obj[Hash(_key)];
                while(temp.GetNext()!=null)
                {
                    temp = temp.GetNext();
                    if (temp.GetElement().GetName().Equals(_key))
                        return temp.GetElement();
                }
            }
            return null;
        }
       private void resize(eNode []obj)// Увеличение размера для уменьшения коллизии
        {
            int oldsize = _size;
            eNode[] oldobj = _obj;
            _size = oldsize * 2;
            _obj = new eNode[_size];
            Program._main.AddTo(oldsize, oldobj);
        }

       protected Hesh(SerializationInfo info, StreamingContext context)// Десериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
 
            _size   = (int)info.GetValue("size",  typeof(int));
            _obj     = (eNode[])info.GetValue("obj",    typeof(eNode[]));
            _use  = (int)    info.GetValue("use", typeof(int));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
       public virtual void GetObjectData(SerializationInfo info, StreamingContext context)// Сериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("size", _size);
            info.AddValue("use", _use);
            info.AddValue("obj", _obj);
        }
    }
}
