//
// System.ComponentModel.PropertyDescriptorCollection.cs
//
// Authors:
//   Rodrigo Moya (rodrigo@ximian.com)
//   Gonzalo Paniagua Javier (gonzalo@ximian.com)
//   Andreas Nahr (ClassDevelopment@A-SoftTech.com)
//
// (C) Rodrigo Moya, 2002
// (c) 2002 Ximian, Inc. (http://www.ximian.com)
// (C) 2003 Andreas Nahr
//

//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System.Collections;
namespace System.ComponentModel
{
	/// <summary>
	/// Represents a collection of PropertyDescriptor objects.
	/// </summary>
	//[DefaultMember ("Item")]
	public class PropertyDescriptorCollection : IList, ICollection, IEnumerable, IDictionary
	{
		public static readonly PropertyDescriptorCollection Empty = new PropertyDescriptorCollection ((ArrayList)null);
		ArrayList properties;

		internal PropertyDescriptorCollection (ArrayList list)
		{
			properties = list;
		}
		
		public PropertyDescriptorCollection (PropertyDescriptor[] properties)
		{
			this.properties = new ArrayList ();
			if (properties == null)
				return;

			this.properties.AddRange (properties);
		}
		
		private PropertyDescriptorCollection ()
		{
		}

		public int Add (PropertyDescriptor value)
		{
			properties.Add (value);
			return properties.Count - 1;
		}

		int IList.Add (object value)
		{
			return Add ((PropertyDescriptor) value);
		}

		void IDictionary.Add (object key, object value)
		{
			Add ((PropertyDescriptor) value);
		}

		public void Clear ()
		{
			properties.Clear ();
		}

		void IList.Clear ()
		{
			Clear ();
		}

		void IDictionary.Clear ()
		{
			Clear ();
		}

		public bool Contains (PropertyDescriptor value)
		{
			return properties.Contains (value);
		}

		bool IList.Contains (object value)
		{
			return Contains ((PropertyDescriptor) value);
		}

		bool IDictionary.Contains (object value)
		{
			return Contains ((PropertyDescriptor) value);
		}

		public void CopyTo (Array array, int index)
		{
			properties.CopyTo (array, index);
		}

		public virtual PropertyDescriptor Find (string name, bool ignoreCase)
		{
			foreach (PropertyDescriptor p in properties) {
				if (0 == String.Compare (name, p.Name, ignoreCase))
					return p;
			}
			return null;
		}

		public virtual IEnumerator GetEnumerator ()
		{
			return properties.GetEnumerator ();
		}

		[MonoTODO]
		IDictionaryEnumerator IDictionary.GetEnumerator ()
		{
			throw new NotImplementedException ();
		}

		public int IndexOf (PropertyDescriptor value)
		{
			return properties.IndexOf (value);
		}

		int IList.IndexOf (object value)
		{
			return IndexOf ((PropertyDescriptor) value);
		}

		public void Insert (int index, PropertyDescriptor value)
		{
			properties.Insert (index, value);
		}

		void IList.Insert (int index, object value)
		{
			Insert (index, (PropertyDescriptor) value);
		}

		public void Remove (PropertyDescriptor value)
		{
			properties.Remove (value);
		}

		void IDictionary.Remove (object value)
		{
			Remove ((PropertyDescriptor) value);
		}

		void IList.Remove (object value)
		{
			Remove ((PropertyDescriptor) value);
		}

		public void RemoveAt (int index)
		{
			properties.RemoveAt (index);
		}

		void IList.RemoveAt (int index)
		{
			RemoveAt (index);
		}

		private PropertyDescriptorCollection CloneCollection ()
		{
			PropertyDescriptorCollection col = new PropertyDescriptorCollection ();
			col.properties = (ArrayList) properties.Clone ();
			return col;
		}
		
		public virtual PropertyDescriptorCollection Sort ()
		{
			PropertyDescriptorCollection col = CloneCollection ();
			col.InternalSort ((IComparer) null);
			return col;
		}

		public virtual PropertyDescriptorCollection Sort (IComparer comparer)
		{
			PropertyDescriptorCollection col = CloneCollection ();
			col.InternalSort (comparer);
			return col;
		}

		public virtual PropertyDescriptorCollection Sort (string[] order) 
		{
			PropertyDescriptorCollection col = CloneCollection ();
			col.InternalSort (order);
			return col;
		}

		public virtual PropertyDescriptorCollection Sort (string[] order, IComparer comparer) 
		{
			PropertyDescriptorCollection col = CloneCollection ();
			ArrayList sorted = col.ExtractItems (order);
			col.InternalSort (comparer);
			sorted.AddRange (col.properties);
			col.properties = sorted;
			return col;
		}

		protected void InternalSort (IComparer ic)
		{
			properties.Sort (ic);
		}

		protected void InternalSort (string [] order)
		{
			ArrayList sorted = ExtractItems (order);
			InternalSort ((IComparer) null);
			sorted.AddRange (properties);
			properties = sorted;
		}
		
		ArrayList ExtractItems (string[] names)
		{
			ArrayList sorted = new ArrayList (properties.Count);
			object[] ext = new object [names.Length];
			
			for (int n=0; n<properties.Count; n++)
			{
				PropertyDescriptor ed = (PropertyDescriptor) properties[n];
				int i = Array.IndexOf (names, ed.Name);
				if (i != -1) {
					ext[i] = ed;
					properties.RemoveAt (n);
					n--;
				}
			}
			foreach (object ob in ext)
				if (ob != null) sorted.Add (ob);
				
			return sorted;
		}
		
		internal PropertyDescriptorCollection Filter (Attribute[] attributes)
		{
			ArrayList list = new ArrayList ();
			foreach (PropertyDescriptor pd in properties)
				if (pd.Attributes.Contains (attributes))
					list.Add (pd);
					
			return new PropertyDescriptorCollection (list);
		}
		
		bool IDictionary.IsFixedSize
		{
			get {
				return true;
			}
		}

		bool IList.IsFixedSize
		{
			get {
				return true;
			}
		}

		bool IList.IsReadOnly
		{
			get {
				return false;
			}
		}

		bool IDictionary.IsReadOnly
		{
			get 
			{
				return false;
			}
		}

		bool ICollection.IsSynchronized
		{
			get {
				return false;
			}
		}

		public int Count
		{
			get {
				return properties.Count;
			}
		}

		object ICollection.SyncRoot
		{
			get {
				return null;
			}
		}

		ICollection IDictionary.Keys
		{
			get {
				string [] keys = new string [properties.Count];
				int i = 0;
				foreach (PropertyDescriptor p in properties)
					keys [i++] = p.Name;
				return keys;
			}
		}

		ICollection IDictionary.Values
		{
			get {
				return (ICollection) properties.Clone ();
			}
		}

		object IDictionary.this [object key]
		{
			get {
				if (!(key is string))
					return null;
				return this [(string) key];
			}
			set {
				if (!(key is string) || (value as PropertyDescriptor) == null)
					throw new ArgumentException ();
				int idx = properties.IndexOf (value);
				if (idx == -1)
					Add ((PropertyDescriptor) value);
				else
					properties [idx] = value;
			}
		}

		public virtual PropertyDescriptor this [string s]
		{
			get {
				return Find (s, false);
			}
		}

		object IList.this [int index]
		{
			get {
				return properties [index];
			}
			set {
				properties [index] = value;
			}
		}

		public virtual PropertyDescriptor this [int index]
		{
			get {
				return (PropertyDescriptor) properties [index];
			}
		}
	}
}

